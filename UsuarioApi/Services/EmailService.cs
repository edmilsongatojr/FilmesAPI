﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;
        private string codeMensagem;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            codeMensagem = mensagem.Conteudo;
            var mensagemDeEmail = CriaCorpoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"),true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(mensagemDeEmail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO Enviar Email: " + ex.Message);
                    //Saida da mensagem pois o SMTP esta dando retorno 5.4.5 Daily user sending quota exceeded. e não envia o email.
                    Console.WriteLine("\nConteudo Mensagem: \n" + codeMensagem);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }   
            }
        }

        private MimeMessage CriaCorpoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            //erro
            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
                mensagemDeEmail.To.AddRange(mensagem.Destinatario);
                mensagemDeEmail.Subject = mensagem.Assunto;
                mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = mensagem.Conteudo
                };
                return mensagemDeEmail;
        }
    }
}
