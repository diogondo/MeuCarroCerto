
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MeuCarroCerto.Models
{

using System;
    using System.Collections.Generic;
    
public partial class t_carros
{

    public long codigo { get; set; }

    public string nome { get; set; }

    public int codigo_marca { get; set; }

    public int ano { get; set; }

    public int codigo_tipo_carroceria { get; set; }

    public long codigo_cor { get; set; }

    public int valor { get; set; }

    public int qtd_ocupantes { get; set; }

    public int trio_eletrico { get; set; }

    public int ar_condicionado { get; set; }

    public int direcao_hidraulica { get; set; }

    public int sensor_de_estacionamento { get; set; }

    public int alarme { get; set; }

    public int cambio_automatico { get; set; }

    public int desempenho_zero_a_cem { get; set; }

    public int central_multimidia { get; set; }

    public int entrada_usb { get; set; }

    public int camera_de_re { get; set; }

    public int farol_neblina { get; set; }

    public int piloto_automatico { get; set; }

    public int roda_liga { get; set; }

    public int teto_solar { get; set; }

    public string historico_fabricante { get; set; }

    public int ano_projeto { get; set; }

    public string rede_concessionaria { get; set; }

    public string disponibilidade_de_pecas { get; set; }

    public int tempo_de_garantia { get; set; }

    public string design { get; set; }



    public virtual t_carrocerias t_carrocerias { get; set; }

    public virtual t_cores t_cores { get; set; }

    public virtual t_marcas t_marcas { get; set; }

}

}
