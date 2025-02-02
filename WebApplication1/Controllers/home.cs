﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class home : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAIBasedResult(string SearchText)
        {
            try {
                string ApiKey = "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";
                string answer = string.Empty;

                var openai = new OpenAIAPI(ApiKey);

                // Crear la solicitud de completion utilizando el modelo gpt-3.5-turbo
                CompletionRequest completionRequest = new CompletionRequest
                {
                    Prompt = SearchText,
                    Model = "gpt-3.5-turbo",  // Usando el modelo gpt-3.5-turbo
                    MaxTokens = 200
                };

                // Obtener la respuesta de OpenAI
                var result = await openai.Completions.CreateCompletionAsync(completionRequest);

                // Procesar la respuesta
                foreach (var item in result.Completions)
                {
                    answer += item.Text;
                }

                return Ok(answer); }

                catch (Exception ex) { return BadRequest($"Razon del error:{ex.Message}"); 
            }


            
            }
        
    }
}

