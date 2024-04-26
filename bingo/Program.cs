int[] numeros = new int[99],sorteados = new int[99];
int[,] cartela1 = new int[5, 5], aux = new int[5,5];
int index_l = 0, index_c = 0, count_c1_preenchidos = 0;
bool ganhador_coluna = false, ganhador_linha = false;

int[,] criarCartela()
{
    int[,] cartela = new int[5,5];
    int index_gravar_numeros = 0;
    for (int i = 1; i <= numeros.Length; i++)
    {
        numeros[index_gravar_numeros] = i;
        index_gravar_numeros++;
    }

    int linha_criar = 0, coluna_criar = 0;
    for (int i = 0; i < 25; i++)
    {
        int j;
        while (true)
        {
            j = new Random().Next(0, 99);
            if (numeros[j] > 0)
            {
                break;
            }
        }

        cartela[linha_criar, coluna_criar] = numeros[j];
        numeros[j] = 0;
        if (coluna_criar == 4)
        {
            linha_criar++;
            coluna_criar = 0;
        }
        else
        {
            coluna_criar++;
        }


    }
    return cartela;
}

int quantidadeJogador()
{
    int qt_jogador = 0;
    do
    {
        Console.Write("Digite a quantidade de jogadores no jogo: ");
        qt_jogador = int.Parse(Console.ReadLine());
    } while (qt_jogador < 2);
   return qt_jogador;
}

int quantidadeCartelas()
{
    int qt_cartelas = 0;
    do
    {
        Console.Write("Digite a Quantidade de cartelas por jogador: ");
        qt_cartelas = int.Parse(Console.ReadLine());
    } while (qt_cartelas < 1);
    return qt_cartelas;
}

void imprimirCartela(int[,] matriz)
{
    for (int linha = 0; linha < 5; linha++)
    {
        Console.WriteLine();
        for (int coluna = 0; coluna < 5;coluna++ )
        {
            Console.Write(matriz[linha,coluna] + " ");
        }
    }
}

void sorteiaNumeros()
{
    int index_gravar_numeros = 0;
    for (int i = 1; i <= numeros.Length; i++)
    {
        numeros[index_gravar_numeros] = i;
        index_gravar_numeros++;
    }

    for (int i = 0; i < numeros.Length; i++)
    {
        int j;
        while (true)
        {
            j = new Random().Next(0, 99);
            if (numeros[j] > 0)
            {
                break;
            }
        }
        sorteados[i] = numeros[j];
        numeros[j] = 0;
    }
}
    int qtd_jogadores = quantidadeJogador();
int qtd_cartelas = quantidadeCartelas();
int[] vetor_jogadores = new int[qtd_jogadores];
int[][][,] vetor_cartelas = new int[qtd_jogadores][][,];

//vetor_cartelas[1][4] = new int[5,5];


// cria o numero maximo de cartelas por jogador;
for (int i = 0; i < qtd_jogadores; i++)
{
    vetor_cartelas[i] = new int[qtd_cartelas][,];

    for (int j = 0; j < qtd_cartelas; j++)
    {
        vetor_cartelas[i][j] = criarCartela();
        int[,] cartela = vetor_cartelas[i][j];
        imprimirCartela(cartela);
        Console.ReadLine();
    }
}

sorteiaNumeros();

//cartelaDoJogadorUm[0][0]

Console.WriteLine("Para");
Console.ReadLine();


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

    for (int linha = 0; linha < 5; linha ++)
    {
        for (int coluna = 0; coluna < 5; coluna++)
        {
            if (cartela1[linha,coluna] == sorteados[i])
            {
                aux[linha, coluna] = 1;
                count_c1_preenchidos++;
                if (count_c1_preenchidos >=5)
                {
                    //verifica coluna
                    for (int linha_aux = 0; linha_aux < 5; linha_aux++)
                    {
                        int count_coluna = 0;
                        for (int coluna_aux = 0; coluna_aux < 5; coluna_aux++)
                        {                            
                            if (aux[linha_aux, coluna_aux] == 1)
                            {
                                count_coluna++;
                                if (count_coluna == 5)
                                {
                                    ganhador_coluna = true;
                                    break;
                                }
                            }
                        }
                    }
                    // verifica linha
                    for (int coluna_aux = 0; coluna_aux < 5; coluna_aux++)
                    {
                        int count_linha = 0;
                        for(int linha_aux = 0; linha_aux < 5; linha_aux++)
                        {
                            if (aux[linha_aux, coluna_aux] == 0)
                            {
                                count_linha++;
                                if (count_linha == 5)
                                {
                                    ganhador_linha = true;
                                    break;
                                }
                            }
                        }

                    }
                }
            }
        }
    }

}


