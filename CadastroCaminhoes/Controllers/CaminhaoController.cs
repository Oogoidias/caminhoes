using CadastroCaminhoes.Models;
using CadastroCaminhoes.Models.ViewModels;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Routing;

namespace CadastroCaminhoes.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly ICaminhaoModeloRepository caminhaoModeloRepository;
        private readonly ICaminhaoRepository caminhaoRepository;

        public CaminhaoController(ICaminhaoModeloRepository caminhaoModeloRepository,
            ICaminhaoRepository caminhaoRepository)
        {
            this.caminhaoModeloRepository = caminhaoModeloRepository;
            this.caminhaoRepository = caminhaoRepository;
        }

        public IActionResult Cadastro(int id)
        {
            try
            {
                CadastroViewModel cadastroViewModel = new CadastroViewModel(
                    id,
                    caminhaoModeloRepository.ListarCaminhaoModeloAtivo(),
                    caminhaoRepository.ListarPorID(id)
                );

                return View("Cadastro", cadastroViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(CadastroViewModel cadastroViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int idCaminhao = cadastroViewModel.idCaminhao;// (int)contextAccessor.HttpContext.Session.GetInt32("idCaminhao");
                    Caminhao caminhao = cadastroViewModel.caminhao;
                    caminhaoRepository.Salvar(caminhao, idCaminhao);

                    return RedirectToAction("Visualizar", new RouteValueDictionary(
                        new { controller = "Caminhao", action = "Visualizar", id = 1 })
                    );
                    //return RedirectToAction("Visualizar", "Caminhao", 10);
                }
                return RedirectToAction("Cadastro");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                caminhaoRepository.Excluir(id);
                return RedirectToAction("Visualizar");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Visualizar(int id)
        {
            try
            {
                VisualizarViewModel visualizarViewModel = new VisualizarViewModel();
                visualizarViewModel.listaCaminhao = caminhaoRepository.ListarTodos();
                visualizarViewModel.TotalCaminhao = caminhaoRepository.ListarTodos().Count;
                ViewData["mensagem"] = id.ToString();
                return View("Visualizar", visualizarViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
