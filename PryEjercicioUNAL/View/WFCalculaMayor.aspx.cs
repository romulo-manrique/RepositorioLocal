using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_WFCalculaMayor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
     public static List<T[]> VarSinRep<T>(T[] original, int largo)
    {
        List<T[]> lista = new List<T[]>();
        int tamaño = original.Length;

        ImplementVarSinRep<T>(original, 0, largo, lista);
        return lista;
    }
    //Recursivo
    private static void ImplementVarSinRep<T>(T[] original, int pos, int largo, List<T[]> lista)
    {
        if (pos == largo)
        {
            T[] copia = new T[pos];
            Array.Copy(original, copia, pos);
            lista.Add(copia);
        }
        else
            for (int i = pos; i < original.Length; i++)
            {
                Swap(ref original[i], ref original[pos]);
                ImplementVarSinRep<T>(original, pos + 1, largo, lista);
                Swap(ref original[i], ref original[pos]);
            }
    }
    //Cambia
    private static void Swap<T>(ref T p, ref T p_2)
    {
        T aux = p;
        p = p_2;
        p_2 = aux;
    }
    public static void Imprime<T>(List<T[]> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            for (int j = 0; j < lista[i].Length; j++)
                Console.Write(lista[i][j]);
            Console.Write(" ");
        }
        Console.WriteLine();
        Console.WriteLine("Cantidad: {0}", lista.Count);
    }

    public static double resultado<T>(List<T[]> lista)
    {
        double valorMaximo = 0;
        double valorActual = 0;       
        string svalorActual = string.Empty;
        for (int i = 0; i < lista.Count; i++)
        {
            svalorActual = string.Empty;
            for (int j = 0; j < lista[i].Length; j++){ 
                //Console.Write(lista[i][j]);
                svalorActual = svalorActual.ToString() + lista[i][j].ToString();
            }

            valorActual = Convert.ToDouble(svalorActual.ToString());

            if (valorActual > valorMaximo){
                valorMaximo = valorActual;
            }           
        }
     
        return valorMaximo;
    }

    [WebMethod]
    public static string CalculaValor(int[] valores)
    {
        string jsondata = string.Empty;
        jsondata = JsonConvert.SerializeObject(resultado<int>(VarSinRep<int>(valores, valores.Length)));
        return jsondata;
    }

}