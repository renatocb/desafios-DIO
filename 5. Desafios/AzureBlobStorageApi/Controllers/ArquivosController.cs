using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AzureBlobStorageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivosController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public ArquivosController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("BlobConnectionString");
            _containerName = configuration.GetValue<string>("BlobContainerName");
        }

        [HttpPost("Upload")]
        public IActionResult UploadArquivo(IFormFile arquivo)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(arquivo.FileName);

            using var data = arquivo.OpenReadStream();

            blob.Upload(data, new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = arquivo.ContentType }
            });

            return Ok(blob.Uri.ToString());
        }

        [HttpPost("download/{nome}")]
        public IActionResult DownloadArquivo(string nome)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(nome);

            if (!blob.Exists())
                return BadRequest();

            var retorno = blob.DownloadContent();

            return File(retorno.Value.Content.ToArray(), retorno.Value.Details.ContentType, blob.Name);
        }

        [HttpPost("apagar/{nome}")]
        public IActionResult DeletarArquivo(string nome)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(nome);

            blob.DeleteIfExists();
            return NoContent();
        }

        
        [HttpPost("Listar")]
        public IActionResult Listar()
        {
            List<BlobDto> blobsDto = new List<BlobDto>();                                                
            BlobContainerClient container = new(_connectionString, _containerName);    

            foreach (var item in container.GetBlobs())
            {
                blobsDto.Add(new BlobDto
                {
                    Nome= item.Name,
                    Tipo = item.Properties.ContentType,
                    Uri = container.Uri.AbsoluteUri + "/" + item.Name
                });
            }

            return Ok(blobsDto);
        }
    }
}