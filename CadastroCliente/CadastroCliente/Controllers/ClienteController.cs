using System;
using CadastroCliente.DB;
using CadastroCliente.Models;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Listar()
        {
            var db = ConexaoBanco.ObterConexao();

            var listaClientes = db.GetAll<Cliente>();

            return View(listaClientes);
        }

        [HttpGet]
        public ActionResult Incluir()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public ActionResult Incluir(IFormCollection form)
        {
            var cliente = new Cliente
            {
                Nome = form["Nome"],
                DataNascimento = DateTime.Parse(form["DataNascimento"]),
                Sexo = Convert.ToChar(form["Sexo"]),
                Cep = form["Cep"],
                Endereco = form["Endereco"],
                Numero = Convert.ToInt32(form["Numero"]),
                Complemento = form["Complemento"],
                Bairro = form["Bairro"],
                Estado = form["Estado"],
                Cidade = form["Cidade"]
            };

            var db = ConexaoBanco.ObterConexao();

            if (ModelState.IsValid)
            {
                db.Insert(cliente);
                return RedirectToAction("Listar");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var db = ConexaoBanco.ObterConexao();
            var cliente = db.Get<Cliente>(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(IFormCollection form)
        {
            var db = ConexaoBanco.ObterConexao();
            int idCliente = Convert.ToInt32(form["IdCliente"]);
            var cliente = db.Get<Cliente>(idCliente);

            cliente.DataNascimento = DateTime.Parse(form["DataNascimento"]);
            cliente.Sexo = Convert.ToChar(form["Sexo"]);
            cliente.Cep = form["Cep"];
            cliente.Endereco = form["Endereco"];
            cliente.Numero = Convert.ToInt32(form["Numero"]);
            cliente.Complemento = form["Complemento"];
            cliente.Nome = form["Nome"];
            cliente.Bairro = form["Bairro"];
            cliente.Estado = form["Estado"];
            cliente.Cidade = form["Cidade"];

            db.Update(cliente);

            return RedirectToAction("Listar");
        }
        
        public ActionResult Excluir(int id)
        {
            var db = ConexaoBanco.ObterConexao();
            var cliente = db.Get<Cliente>(id);
            db.Delete(cliente);
            
            return RedirectToAction("Listar");
        }
    }
}