using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjetoArquitetura.Models.Models;
using System.Net.Http.Headers;

namespace ProjetoArquitetura.Front.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index(string? mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;


            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());
            //HttpResponseMessage response = cliente.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterTodosClientes").Result;

            HttpResponseMessage response = client.GetAsync($"https://localhost:7086/api/Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }

        public IActionResult Details(string CPF)
        {

            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());
            //HttpResponseMessage response = cliente.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterDadosCliente?CPF={CPF}").Result;

            HttpResponseMessage response = client.GetAsync($"https://localhost:7086/api/Cliente/ObterDadosCliente?CPF={CPF}").Result;


            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ClienteModel>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create([FromForm] ClienteModel clienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());
                    //HttpResponseMessage response = cliente.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", clienteModel).Result;

                    HttpResponseMessage response = client.PostAsJsonAsync($"https://localhost:7086/api/Cliente", clienteModel).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Deu Zica");
                    }

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;

                return View();
            }
        }

        public IActionResult Edit(string CPF)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());
            //HttpResponseMessage response = cliente.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterDadosCliente?CPF={CPF}").Result;


            HttpResponseMessage response = client.GetAsync($"https://localhost:7086/api/Cliente/ObterDadosCliente?CPF={CPF}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ClienteModel>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }

        }

        public IActionResult Delete(string CPF)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

                HttpResponseMessage response = client.DeleteAsync($"https://localhost:7086/api/Cliente?cpf={CPF}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { mensagem = "Registro deletado!", sucesso = true });
                }
                else
                {
                    throw new Exception("Deu Zica");
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Não foi possivel excluir o fornecedor " + ex.Message;

                return View();
            }

        }
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
