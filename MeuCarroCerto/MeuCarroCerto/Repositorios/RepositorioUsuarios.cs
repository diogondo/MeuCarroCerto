using MeuCarroCerto.Models;
using MeuCarroCerto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MeuCarroCerto.Repositorios
{
    public class RepositorioUsuarios
    {
        public static string GetSwcSH1(string value)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = GetSwcSH1(Senha);
            try
            {
                using (EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB())
                {
                    var queryAutenticaUsuarios = db.t_usuarios.Where(x => x.login == Login && x.senha == SenhaCriptografada).SingleOrDefault();

                    if (queryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(queryAutenticaUsuarios.codigo);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static t_usuarios RecuperaUsuarioPorID(long codigo)
        {
            try
            {
                using (EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB())
                {
                    var usuario = db.t_usuarios.Where(u => u.codigo == codigo).SingleOrDefault();
                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static t_usuarios VerificaSeOUsuarioEstaLogado()
        {
            var usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (usuario == null)
            {
                return null;
            }
            else
            {
                long codigo = Convert.ToInt64(RepositorioCriptografia.Descriptografar(usuario.Values["codigo"]));

                var usuarioRetornado = RecuperaUsuarioPorID(codigo);
                return usuarioRetornado;

            }
        }
    }
}