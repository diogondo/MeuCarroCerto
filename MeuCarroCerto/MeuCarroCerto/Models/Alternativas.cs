using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    public class Alternativas

    {   
        //Necessidade    
        public bool ar_condicionado { get; set; }   
        public bool trio_eletrico { get; set; }
        public bool direcao_hidrulica { get; set; }
        public bool banco_de_couro { get; set; }
        public bool sensor_de_estacionamento { get; set; }
        public bool alarme { get; set; }
        public bool cambio_automatico { get; set; }
        public bool desempenho_0_a_100 { get; set; }
        public bool central_multimidia { get; set; }
        public bool sistema_de_som_com_entrada_USB { get; set; }
        public bool camera_de_re { get; set; }
        public bool farol_de_neblina { get; set; }
        public bool piloto_automatico { get; set; }
        public bool rodas_de_liga { get; set; }
        public bool teto_solar { get; set; }

        //Qualidade
        public bool historico_de_confiabilidade_da_fabricante { get; set; }
        public bool ano_do_projeto_do_automovel { get; set; }
        public bool rede_de_concessionarias { get; set; }
        public bool disponibilidade_de_pecas { get; set; }
        public bool tempo_de_garantia { get; set; }
        public bool design { get; set; }

        //Segurança
        public bool freio_com_ABS { get; set; }
        public bool airbag { get; set; }
        public bool avaliacao_crash_test { get; set; }
        public bool controle_de_tracao { get; set; }
        public bool freio_com_EBD { get; set; }
        public bool freio_com_BAS { get; set; }
        public bool controle_de_estabilidade_ESP { get; set; }
        public bool blindagem { get; set; }

        //Valor
        public bool consumo { get; set; }
        public bool IPVA { get; set; }
        public bool valor_do_seguro { get; set; }
        public bool custo_de_manutencao { get; set; }

        //Marketing
        public bool conquista { get; set; }
        public bool exclusividade { get; set; }
        public bool boa_imagem { get; set; }
        public bool aventureiro { get; set; }

  
    }
}