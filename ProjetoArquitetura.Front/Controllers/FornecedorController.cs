using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoArquitetura.Models.Models;
using System.Net.Http.Headers;

namespace ProjetoArquitetura.Front.Controllers
{
    public class FornecedorController : Controller
    {
        public IActionResult Index(string? mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;


            HttpClient fornecedor = new();
            fornecedor.DefaultRequestHeaders.Accept.Clear();
            fornecedor.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

            //HttpResponseMessage response = cliente.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/ObterTodosClientes").Result;
            HttpResponseMessage response = fornecedor.GetAsync($"https://localhost:7086/api/Fornecedor").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<FornecedorModel>>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }

        public IActionResult Details(string CNPJ)
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());


            HttpResponseMessage response = client.GetAsync($"https://localhost:7086/api/Fornecedor/ObterDadosFornecedor?CNPJ={CNPJ}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FornecedorModel>(conteudo));
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
        public IActionResult Create([FromForm] FornecedorModel fornecedorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());


                    HttpResponseMessage response = client.PostAsJsonAsync($"https://localhost:7086/api/Fornecedor", fornecedorModel).Result;

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

        public IActionResult Edit(string CNPJ)
        {

            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

            HttpResponseMessage response = client.GetAsync($"https://localhost:7086/api/Fornecedor/ObterDadosFornecedor?CNPJ={CNPJ}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FornecedorModel>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }
        public IActionResult Edit([FromForm] FornecedorModel fornecedorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"https://localhost:7086/api/Fornecedor", fornecedorModel).Result;

                    if (true)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
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

        public IActionResult Delete(string CNPJ)
        {
            try
            {
                HttpClient client = new();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

                HttpResponseMessage response = client.DeleteAsync($"https://localhost:7086/api/Fornecedor?CNPJ={CNPJ}").Result;

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

        public IActionResult Delete(string CNPJ, IFormCollection collection)
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
