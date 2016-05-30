using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuCarroCerto.Models;

namespace MeuCarroCerto.Controllers
{
    public class ResultadoController : Controller
    {
        //
        // GET: /Resultado/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();

        public ActionResult Index(Alternativas alternativas)
        {
            
            MeuCarroCerto.Models.Filtros filtros = new MeuCarroCerto.Models.Filtros();
            List<t_carros> carros = new List<t_carros>();
            List<CarrosXAlternativas> listCarrosXAlternativas = new List<CarrosXAlternativas>();
            BancoSession bd = BancoSession.CriarConexaoBancoSession();
            filtros = bd.ListaFiltros[0];
            
            var teste = db.t_carros.SqlQuery("select * from t_carros where valor between " + filtros.valor1 + " and " + filtros.valor2 + " and ano between " + filtros.ano1 + " and " + filtros.ano2 + " and qtd_ocupantes=" + filtros.qtd_ocupante + " and codigo_tipo_carroceria = " + filtros.tipo_carroceria + ";");
            ViewBag.alternativas = alternativas;
            ViewBag.cont=0;
            foreach (var item in teste)
            {
                CarrosXAlternativas carroAlt = new CarrosXAlternativas();
                carroAlt.idCarro = item.codigo;
                //Necessidade
                    if(alternativas.ar_condicionado){
                        carroAlt.necessidade = carroAlt.necessidade + item.ar_condicionado;
                    }
                    if (alternativas.trio_eletrico)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.trio_eletrico;
                    }
                    if (alternativas.direcao_hidrulica)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.direcao_hidraulica;
                    }
                    if (alternativas.banco_de_couro)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.banco_de_couro;
                    }
                    if (alternativas.sensor_de_estacionamento)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.sensor_de_estacionamento;
                    }
                    if (alternativas.alarme)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.alarme;
                    }
                    if (alternativas.cambio_automatico)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.cambio_automatico;
                    }
                    if (alternativas.desempenho_0_a_100)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.desempenho_zero_a_cem;
                    }
                    if (alternativas.central_multimidia)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.central_multimidia;
                    }
                    if (alternativas.sistema_de_som_com_entrada_USB)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.entrada_usb;
                    }
                    if (alternativas.camera_de_re)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.camera_de_re;
                    }
                    if (alternativas.farol_de_neblina)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.farol_neblina;
                    }
                    if (alternativas.piloto_automatico)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.piloto_automatico;
                    }
                    if (alternativas.rodas_de_liga)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.roda_liga;
                    }
                    if (alternativas.teto_solar)
                    {
                        carroAlt.necessidade = carroAlt.necessidade + item.teto_solar;
                    }

                //Qualidade
                    if (alternativas.historico_de_confiabilidade_da_fabricante)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.historico_fabricante);
                    }
                    if (alternativas.ano_do_projeto_do_automovel)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + item.ano_projeto;
                    }
                    if (alternativas.rede_de_concessionarias)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.rede_concessionaria);
                    }
                    if (alternativas.disponibilidade_de_pecas)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.disponibilidade_de_pecas);
                    }
                    if (alternativas.tempo_de_garantia)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + item.tempo_de_garantia;
                    }
                    if (alternativas.design)
                    {
                        carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.design);
                    }
                //Segurança
                    if (alternativas.freio_com_ABS)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.freio_com_ABS;
                    }
                    if (alternativas.airbag)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.airbag;
                    }
                    if (alternativas.avaliacao_crash_test)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.avaliacao_crash_test;
                    }
                    if (alternativas.controle_de_tracao)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.controle_de_tracao;
                    }
                    if (alternativas.freio_com_EBD)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.freio_com_EBD;
                    }
                    if (alternativas.freio_com_BAS)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.freio_com_BAS;
                    }
                    if (alternativas.controle_de_estabilidade_ESP)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.controle_de_estabilidade_ESP;
                    }
                    if (alternativas.blindagem)
                    {
                        carroAlt.seguranca = carroAlt.seguranca + item.blindagem;
                    }
                //Valor
                    if (alternativas.consumo)
                    {
                        carroAlt.valor = carroAlt.valor + item.consumo;
                    }
                    if (alternativas.IPVA)
                    {
                        carroAlt.valor = carroAlt.valor + item.ipva;
                    }
                    if (alternativas.valor_do_seguro)
                    {
                        carroAlt.valor = carroAlt.valor + item.valor_do_seguro;
                    }
                    if (alternativas.custo_de_manutencao)
                    {
                        carroAlt.valor = carroAlt.valor + item.custo_de_manutencao;
                    }
                //Marketing
                    if (alternativas.conquista)
                    {
                        carroAlt.marketing = carroAlt.marketing + item.conquista;
                    }
                    if (alternativas.exclusividade)
                    {
                        carroAlt.marketing = carroAlt.marketing + item.exclusividade;
                    }
                    if (alternativas.boa_imagem)
                    {
                        carroAlt.marketing = carroAlt.marketing + item.boa_imagem;
                    }
                    if (alternativas.aventureiro)
                    {
                        carroAlt.marketing = carroAlt.marketing + item.aventureiro;
                    }

                    listCarrosXAlternativas.Add(carroAlt);
                    carros.Add(item);

            
            }
            int count = 0;
            int somaNecessidade = listCarrosXAlternativas.Sum(i => i.necessidade);
            int somaQualidade = listCarrosXAlternativas.Sum(i => i.qualidade);
            int somaSeguranca = listCarrosXAlternativas.Sum(i => i.seguranca);
            int somaValor = listCarrosXAlternativas.Sum(i => i.valor);
            int somaMarketing = listCarrosXAlternativas.Sum(i => i.marketing);

            double necessidadeMatriz = bd.ListamatrizCriteios[0].vNormaNecessidade();
            double qualidadeMatriz = bd.ListamatrizCriteios[0].vNormaQualidade();
            double segurancaMatriz = bd.ListamatrizCriteios[0].vNormaSeguranca();
            double valorMatriz = bd.ListamatrizCriteios[0].vNormaValor();
            double marketingMatriz = bd.ListamatrizCriteios[0].vNormaMarketing();

            //Necessidade
            foreach (var item in listCarrosXAlternativas)
            {

                listCarrosXAlternativas[count].necessidadePercent =(double)item.necessidade / (double)somaNecessidade;
                listCarrosXAlternativas[count].qualidadePercent = (double)item.qualidade / (double)somaQualidade;
                listCarrosXAlternativas[count].segurancaPercent = ((double)item.seguranca / (double)somaSeguranca);
                //Harmonizar Normalizar
                listCarrosXAlternativas[count].valorPercent = ((((double)somaValor / (double)item.valor)) / (double)somaValor);
                listCarrosXAlternativas[count].marketingPercent = ((double)item.marketing / (double)somaMarketing);
                listCarrosXAlternativas[count].vetDecisao = (listCarrosXAlternativas[count].necessidadePercent * necessidadeMatriz) + (listCarrosXAlternativas[count].qualidadePercent * qualidadeMatriz) + (listCarrosXAlternativas[count].segurancaPercent * segurancaMatriz) + (listCarrosXAlternativas[count].valorPercent * valorMatriz) + (listCarrosXAlternativas[count].marketingPercent * marketingMatriz);
                count = count + 1;
            }
            carros.Clear();
            
            int contaCarros = 0;
            foreach (var item in listCarrosXAlternativas.OrderByDescending(c => c.vetDecisao))
            {
                if (contaCarros > 2)
                {
                    break;
                }
            
                carros.Add(db.t_carros.Find(item.idCarro));
                contaCarros = contaCarros + 1;
            }
            return View(carros);
        }
        public ActionResult Index2(Alternativas alternativas)
        {

            MeuCarroCerto.Models.Filtros filtros = new MeuCarroCerto.Models.Filtros();
            List<t_carros> carros = new List<t_carros>();
            List<CarrosXAlternativas> listCarrosXAlternativas = new List<CarrosXAlternativas>();
            BancoSession bd = BancoSession.CriarConexaoBancoSession();
            filtros = bd.ListaFiltros[0];

            var teste = db.t_carros.SqlQuery("select * from t_carros where valor between " + filtros.valor1 + " and " + filtros.valor2 + " and ano between " + filtros.ano1 + " and " + filtros.ano2 + " and qtd_ocupantes=" + filtros.qtd_ocupante + " and codigo_tipo_carroceria = " + filtros.tipo_carroceria + ";");
            ViewBag.alternativas = alternativas;
            ViewBag.cont = 0;
            foreach (var item in teste)
            {
                CarrosXAlternativas carroAlt = new CarrosXAlternativas();
                carroAlt.idCarro = item.codigo;
                //Necessidade
                if (alternativas.ar_condicionado)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.ar_condicionado;
                }
                if (alternativas.trio_eletrico)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.trio_eletrico;
                }
                if (alternativas.direcao_hidrulica)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.direcao_hidraulica;
                }
                if (alternativas.banco_de_couro)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.banco_de_couro;
                }
                if (alternativas.sensor_de_estacionamento)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.sensor_de_estacionamento;
                }
                if (alternativas.alarme)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.alarme;
                }
                if (alternativas.cambio_automatico)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.cambio_automatico;
                }
                if (alternativas.desempenho_0_a_100)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.desempenho_zero_a_cem;
                }
                if (alternativas.central_multimidia)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.central_multimidia;
                }
                if (alternativas.sistema_de_som_com_entrada_USB)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.entrada_usb;
                }
                if (alternativas.camera_de_re)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.camera_de_re;
                }
                if (alternativas.farol_de_neblina)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.farol_neblina;
                }
                if (alternativas.piloto_automatico)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.piloto_automatico;
                }
                if (alternativas.rodas_de_liga)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.roda_liga;
                }
                if (alternativas.teto_solar)
                {
                    carroAlt.necessidade = carroAlt.necessidade + item.teto_solar;
                }

                //Qualidade
                if (alternativas.historico_de_confiabilidade_da_fabricante)
                {
                    carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.historico_fabricante);
                }
                if (alternativas.ano_do_projeto_do_automovel)
                {
                    carroAlt.qualidade = carroAlt.qualidade + item.ano_projeto;
                }
                if (alternativas.rede_de_concessionarias)
                {
                    carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.rede_concessionaria);
                }
                if (alternativas.disponibilidade_de_pecas)
                {
                    carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.disponibilidade_de_pecas);
                }
                if (alternativas.tempo_de_garantia)
                {
                    carroAlt.qualidade = carroAlt.qualidade + item.tempo_de_garantia;
                }
                if (alternativas.design)
                {
                    carroAlt.qualidade = carroAlt.qualidade + Convert.ToInt32(item.design);
                }
                //Segurança
                if (alternativas.freio_com_ABS)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.freio_com_ABS;
                }
                if (alternativas.airbag)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.airbag;
                }
                if (alternativas.avaliacao_crash_test)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.avaliacao_crash_test;
                }
                if (alternativas.controle_de_tracao)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.controle_de_tracao;
                }
                if (alternativas.freio_com_EBD)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.freio_com_EBD;
                }
                if (alternativas.freio_com_BAS)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.freio_com_BAS;
                }
                if (alternativas.controle_de_estabilidade_ESP)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.controle_de_estabilidade_ESP;
                }
                if (alternativas.blindagem)
                {
                    carroAlt.seguranca = carroAlt.seguranca + item.blindagem;
                }
                //Valor
                if (alternativas.consumo)
                {
                    carroAlt.valor = carroAlt.valor + item.consumo;
                }
                if (alternativas.IPVA)
                {
                    carroAlt.valor = carroAlt.valor + item.ipva;
                }
                if (alternativas.valor_do_seguro)
                {
                    carroAlt.valor = carroAlt.valor + item.valor_do_seguro;
                }
                if (alternativas.custo_de_manutencao)
                {
                    carroAlt.valor = carroAlt.valor + item.custo_de_manutencao;
                }
                //Marketing
                if (alternativas.conquista)
                {
                    carroAlt.marketing = carroAlt.marketing + item.conquista;
                }
                if (alternativas.exclusividade)
                {
                    carroAlt.marketing = carroAlt.marketing + item.exclusividade;
                }
                if (alternativas.boa_imagem)
                {
                    carroAlt.marketing = carroAlt.marketing + item.boa_imagem;
                }
                if (alternativas.aventureiro)
                {
                    carroAlt.marketing = carroAlt.marketing + item.aventureiro;
                }

                listCarrosXAlternativas.Add(carroAlt);
                carros.Add(item);


            }
            int count = 0;
            int somaNecessidade = listCarrosXAlternativas.Sum(i => i.necessidade);
            int somaQualidade = listCarrosXAlternativas.Sum(i => i.qualidade);
            int somaSeguranca = listCarrosXAlternativas.Sum(i => i.seguranca);
            int somaValor = listCarrosXAlternativas.Sum(i => i.valor);
            int somaMarketing = listCarrosXAlternativas.Sum(i => i.marketing);

            double necessidadeMatriz = bd.ListamatrizCriteios[0].vNormaNecessidade();
            double qualidadeMatriz = bd.ListamatrizCriteios[0].vNormaQualidade();
            double segurancaMatriz = bd.ListamatrizCriteios[0].vNormaSeguranca();
            double valorMatriz = bd.ListamatrizCriteios[0].vNormaValor();
            double marketingMatriz = bd.ListamatrizCriteios[0].vNormaMarketing();

            //Necessidade
            foreach (var item in listCarrosXAlternativas)
            {

                listCarrosXAlternativas[count].necessidadePercent = (double)item.necessidade / (double)somaNecessidade;
                listCarrosXAlternativas[count].qualidadePercent = (double)item.qualidade / (double)somaQualidade;
                listCarrosXAlternativas[count].segurancaPercent = ((double)item.seguranca / (double)somaSeguranca);
                //Harmonizar Normalizar
                listCarrosXAlternativas[count].valorPercent = ((((double)somaValor / (double)item.valor)) / (double)somaValor);
                listCarrosXAlternativas[count].marketingPercent = ((double)item.marketing / (double)somaMarketing);
                listCarrosXAlternativas[count].vetDecisao = (listCarrosXAlternativas[count].necessidadePercent * necessidadeMatriz) + (listCarrosXAlternativas[count].qualidadePercent * qualidadeMatriz) + (listCarrosXAlternativas[count].segurancaPercent * segurancaMatriz) + (listCarrosXAlternativas[count].valorPercent * valorMatriz) + (listCarrosXAlternativas[count].marketingPercent * marketingMatriz);
                count = count + 1;
            }
            carros.Clear();

            int contaCarros = 0;
            foreach (var item in listCarrosXAlternativas.OrderByDescending(c => c.vetDecisao))
            {
                if (contaCarros > 2)
                {
                    break;
                }
                carros.Add(db.t_carros.Find(item.idCarro));

                var testes = db.t_marcas.SqlQuery("select * from t_marcas where codigo=" + carros[contaCarros].codigo_marca + ";" );
    
            foreach (var itens in testes)
            {
                carros[contaCarros].marca_comp = itens.nome;
                
            }
                contaCarros = contaCarros + 1;
            }
            bd.LimparBanco();
            return View(carros);
        }
    }
}
