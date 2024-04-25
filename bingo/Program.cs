int[] numeros = new int[99],sorteados = new int[99];
int[,] cartela = new int[5, 5], aux = new int[5,5];
int index_l = 0, index_c = 0, count_c1_preenchidos = 0;
bool ganhador_coluna = false;


for (int i = 1; i < numeros.Length; i++)
{
    numeros[i] = i;
}

for (int i = 0; i < cartela.Length; i++)
{
    int linha = 0, coluna = 0;
    int j;
    while (true)
    {
        j = new Random().Next(0, 99);
        if (numeros[j] > 0)
        {
            break;
        }
    }

    cartela[linha, coluna] = numeros[j];
    numeros[j] = 0;
    if (linha > 4)
    {
        coluna++;
    }
    linha++;
}

for (int i = 1; i < numeros.Length; i++)
{
    numeros[i] = i;
}

for  (int i = 0; i < numeros.Length; i++)
{
    int j;
    while (true)
    {
        j = new Random().Next(0,99);
        if (numeros[j] > 0)
        {
            break;
        }
    }
    sorteados[i] = numeros[j];
    numeros[j] = 0;

    for (int linha = 0; linha < cartela.Length; linha ++)
    {
        for (int coluna = 0; coluna < cartela.Length; coluna++)
        {
            if (cartela[linha,coluna] == sorteados[i])
            {
                aux[linha, coluna] = 1;
                count_c1_preenchidos++;
                if (count_c1_preenchidos >=5)
                {
                    //verifica coluna
                    for (int linha_aux = 0; linha_aux < aux.Length; linha_aux++)
                    {
                        int count_coluna = 0;
                        for (int coluna_aux = 0; coluna_aux < aux.Length; coluna_aux++)
                        {                            
                            if (aux[linha_aux, coluna_aux] == 0)
                            {
                                count_coluna++;
                                if (count_coluna == 3)
                                {
                                    ganhador_coluna = true;
                                    break;
                                }
                            }
                        }
                    }
                    // verifica linha
                    for (int coluna_aux = 0; coluna_aux < aux.Length; coluna_aux++)
                    {

                    }
                }
            }
        }
    }

}


