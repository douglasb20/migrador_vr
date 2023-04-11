﻿using Npgsql;
using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MigradorRP
{

    static class Funcoes
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public static void moverForm(Form frm)
        {
            ReleaseCapture();
            SendMessage(frm.Handle, 0x112, 0xf012, 0);
        }

        private static string titulo = ConfigurationManager.AppSettings["appTitle"];
        public static void ErrorMessage(string text)
        {
            MessageBox.Show(text, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Chama um alerta personalizado conforme você define a mensagem e tipo
        /// os tipos são `info`, `question`, `warning` e `error`.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tipo"></param>
        /// <returns>Retorna uma caixa de messagem pre definido</returns>
        public static DialogResult ChamaAlerta(string texto = null, string tipo = "info")
        {
            DialogResult resultado = new DialogResult();
            switch (tipo.ToLower())
            {
                case "question":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                case "warning":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "error":
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    resultado = MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
            }

            return resultado;

        }

        /// <summary>
        /// Função para adicionar uma máscara específica na string
        /// </summary>
        /// <param name="texto">Texto que irá receber a máscara</param>
        /// <param name="mask"></param>
        /// <returns>Retorna uma string com a máscara definida</returns>
        public static string Mascara(string texto, string mask)
        {
            string ret = "";
            int k = 0;

            for (int i = 0; i <= mask.Length - 1; i++)
            {
                if (mask[i].ToString() == "#")
                {
                    if (!String.IsNullOrEmpty(texto[k].ToString()))
                    {
                        ret += texto[k++].ToString();
                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(mask[i].ToString()))
                    {
                        ret += mask[i].ToString();
                    }

                }
            }

            return ret;
        }

        /// <summary>
        /// Função para tirar acento da string.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>Retorna uma string sem os acentos definidos.</returns>
        public static string TiraAcento(string texto)
        {
            try
            {
                texto = texto.Trim();

                if (string.IsNullOrEmpty(texto))
                {
                    return texto;
                }

                texto = texto.ToUpper();
                texto = texto.Replace("Á", "A");
                texto = texto.Replace("À", "A");
                texto = texto.Replace("Ã", "A");
                texto = texto.Replace("Â", "A");
                texto = texto.Replace("É", "E");
                texto = texto.Replace("Ê", "E");
                texto = texto.Replace("È", "E");
                texto = texto.Replace("Í", "I");
                texto = texto.Replace("Ì", "I");
                texto = texto.Replace("Î", "I");
                texto = texto.Replace("Ó", "O");
                texto = texto.Replace("Ò", "O");
                texto = texto.Replace("Ô", "O");
                texto = texto.Replace("Õ", "O");
                texto = texto.Replace("Ú", "U");
                texto = texto.Replace("Ù", "U");
                texto = texto.Replace("Ç", "C");
                texto = texto.Replace("&", "");
                texto = texto.Replace("!", "");
                texto = texto.Replace("*", "");
                texto = texto.Replace(";", "");
                texto = texto.Replace("'", "");

                return texto;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
