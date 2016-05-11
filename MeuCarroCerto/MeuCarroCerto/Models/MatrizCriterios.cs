using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    public class MatrizCriterios
    {

        double[,] matrizCriterios = new double[5, 6];

        public void CarregaMatriz(CriteriosPessoa criteriosPesso)
        {
            //Necessidade
            matrizCriterios[0, 0] = 1;//
            matrizCriterios[0, 1] = comparaNecessidade(criteriosPesso.necessidade, criteriosPesso.qualidade);
            matrizCriterios[0, 2] = comparaNecessidade(criteriosPesso.necessidade, criteriosPesso.segurança); ;
            matrizCriterios[0, 3] = comparaNecessidade(criteriosPesso.necessidade, criteriosPesso.valor); ;
            matrizCriterios[0, 4] = comparaNecessidade(criteriosPesso.necessidade, criteriosPesso.marketing); ;
            matrizCriterios[0, 5] = matrizCriterios[0, 0] + matrizCriterios[0, 1] + matrizCriterios[0, 2] + matrizCriterios[0, 3] + matrizCriterios[0, 4];
            
            //Qualidade
            matrizCriterios[1, 0] = comparaNecessidade(criteriosPesso.qualidade, criteriosPesso.necessidade); ;
            matrizCriterios[1, 1] = 1;//
            matrizCriterios[1, 2] = comparaNecessidade(criteriosPesso.qualidade, criteriosPesso.segurança); ;
            matrizCriterios[1, 3] = comparaNecessidade(criteriosPesso.qualidade, criteriosPesso.valor); ;
            matrizCriterios[1, 4] = comparaNecessidade(criteriosPesso.qualidade, criteriosPesso.marketing); ;
            matrizCriterios[1, 5] = matrizCriterios[1, 0] + matrizCriterios[1, 1] + matrizCriterios[1, 2] + matrizCriterios[1, 3] + matrizCriterios[1, 4];

            //Segurança
            matrizCriterios[2, 0] = comparaNecessidade(criteriosPesso.segurança, criteriosPesso.necessidade); ;
            matrizCriterios[2, 1] = comparaNecessidade(criteriosPesso.segurança, criteriosPesso.qualidade);
            matrizCriterios[2, 2] = 1;//
            matrizCriterios[2, 3] = comparaNecessidade(criteriosPesso.segurança, criteriosPesso.valor); ;
            matrizCriterios[2, 4] = comparaNecessidade(criteriosPesso.segurança, criteriosPesso.marketing); ;
            matrizCriterios[2, 5] = matrizCriterios[2, 0] + matrizCriterios[2, 1] + matrizCriterios[2, 2] + matrizCriterios[2, 3] + matrizCriterios[2, 4];

            //Valor
            matrizCriterios[3, 0] = comparaNecessidade(criteriosPesso.valor, criteriosPesso.necessidade);
            matrizCriterios[3, 1] = comparaNecessidade(criteriosPesso.valor, criteriosPesso.qualidade);
            matrizCriterios[3, 2] = comparaNecessidade(criteriosPesso.valor, criteriosPesso.segurança); ;
            matrizCriterios[3, 3] = 1;//
            matrizCriterios[3, 4] = comparaNecessidade(criteriosPesso.valor, criteriosPesso.marketing); ;
            matrizCriterios[3, 5] = matrizCriterios[3, 0] + matrizCriterios[3, 1] + matrizCriterios[3, 2] + matrizCriterios[3, 3] + matrizCriterios[3, 4];

            //Marketing
            matrizCriterios[4, 0] = comparaNecessidade(criteriosPesso.marketing, criteriosPesso.qualidade);
            matrizCriterios[4, 1] = comparaNecessidade(criteriosPesso.marketing, criteriosPesso.qualidade);
            matrizCriterios[4, 2] = comparaNecessidade(criteriosPesso.marketing, criteriosPesso.segurança); ;
            matrizCriterios[4, 3] = comparaNecessidade(criteriosPesso.marketing, criteriosPesso.valor); ;
            matrizCriterios[4, 4] = 1;//
            matrizCriterios[4, 5] = matrizCriterios[4, 0] + matrizCriterios[4, 1] + matrizCriterios[4, 2] + matrizCriterios[4, 3] + matrizCriterios[4, 4];


        }


        public double comparaNecessidade(int coluna, int linha)
        {
            double compara = 0;

            if (coluna == linha)            {
                compara = 1.0;
            }
            else if (coluna < linha)
            {
                compara = linha - coluna;
            }
            else
            {
                compara = 1.0 / ((coluna - linha));
            }


            return compara;
        }

        public double autoVetor()
        {
            double autoVetor  = 0;

            double necessidade = 0;
            double qualidade = 0;
            double segurança = 0;
            double valor = 0;
            double marketing = 0;

            necessidade = Math.Pow((this.matrizCriterios[0, 0] * this.matrizCriterios[1, 0] * this.matrizCriterios[2, 0] * this.matrizCriterios[3, 0] * this.matrizCriterios[4, 0]) , (1.0 / 5.0));
            qualidade = Math.Pow((this.matrizCriterios[0, 1] * this.matrizCriterios[1, 1] * this.matrizCriterios[2, 1] * this.matrizCriterios[3, 1] * this.matrizCriterios[4, 1]), (1.0 / 5.0));
            segurança = Math.Pow((this.matrizCriterios[0, 2] * this.matrizCriterios[1, 2] * this.matrizCriterios[2, 2] * this.matrizCriterios[3, 2] * this.matrizCriterios[4, 2]), (1.0 / 5.0));
            valor = Math.Pow((this.matrizCriterios[0, 3] * this.matrizCriterios[1, 3] * this.matrizCriterios[2, 3] * this.matrizCriterios[3, 3] * this.matrizCriterios[4, 3]), (1.0 / 5.0));
            marketing = Math.Pow((this.matrizCriterios[0, 4] * this.matrizCriterios[1, 4] * this.matrizCriterios[2, 4] * this.matrizCriterios[3, 4] * this.matrizCriterios[4, 4]), (1 / 5.0));

            autoVetor = necessidade + qualidade + segurança + valor + marketing;
            return autoVetor;
        }

        public double vNormaNecessidade()
        {
            double necessidade = (Math.Pow((this.matrizCriterios[0, 0] * this.matrizCriterios[1, 0] * this.matrizCriterios[2, 0] * this.matrizCriterios[3, 0] * this.matrizCriterios[4, 0]), (1.0 / 5.0))) / this.autoVetor();
             return necessidade;
        }
        public double vNormaQualidade()
        {
            double necessidade = (Math.Pow((this.matrizCriterios[0, 1] * this.matrizCriterios[1, 1] * this.matrizCriterios[2, 1] * this.matrizCriterios[3, 1] * this.matrizCriterios[4, 1]), (1.0 / 5.0))) / this.autoVetor();
            return necessidade;
        }
        public double vNormaSeguranca()
        {
            double necessidade = (Math.Pow((this.matrizCriterios[0, 2] * this.matrizCriterios[1, 2] * this.matrizCriterios[2, 2] * this.matrizCriterios[3, 2] * this.matrizCriterios[4, 2]), (1.0 / 5.0))) / this.autoVetor();
            return necessidade;
        }
        public double vNormaValor()
        {
            double necessidade = (Math.Pow((this.matrizCriterios[0, 3] * this.matrizCriterios[1, 3] * this.matrizCriterios[2, 3] * this.matrizCriterios[3, 3] * this.matrizCriterios[4, 3]), (1.0 / 5.0))) / this.autoVetor();
            return necessidade;
        }
        public double vNormaMarketing()
        {
            double necessidade = (Math.Pow((this.matrizCriterios[0, 4] * this.matrizCriterios[1, 4] * this.matrizCriterios[2, 4] * this.matrizCriterios[3, 4] * this.matrizCriterios[4, 4]), (1.0 / 5.0))) / this.autoVetor();
            return necessidade;
        }
        public double lMax()
        {
            double lmax = 0;


            lmax = (matrizCriterios[0, 5] * vNormaNecessidade()) + (matrizCriterios[1, 5] * vNormaQualidade()) + (matrizCriterios[2, 5] * vNormaSeguranca()) + (matrizCriterios[3, 5] * vNormaValor()) + (matrizCriterios[4, 5] * vNormaMarketing());

            return lmax;
        }
        public double Ic()
        {
            double ic = 0;
            ic = (lMax() - 5.0) / (5.0 - 1.0);
            return ic;

        }
        public double Rc()
        {
            double rc = 0;
            rc = Ic() / 1.12;
            return rc;
        }
    }
}