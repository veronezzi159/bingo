using System.Security;

int[] numeros = new int[99],sorteados = new int[99];
int[,] cartela1 = new int[5, 5], aux = new int[5,5];
bool ganhador_coluna = false, ganhador_linha = false, ganhador_cartela = false;
int rodada_coluna = 0, rodada_linha = 0, rodada_cartela = 0;

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

void imprimirCartela(int[,] matriz,int[,] matriz_aux)
{
    Console.WriteLine();
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (matriz_aux[i, j] == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(matriz[i, j] + " ");
                Console.ResetColor();
            }
            else
            {


                Console.Write(matriz[i, j] + " ");
            }
        }
        Console.WriteLine();
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

void imprimirNumerosSorteados(int num,int indice)
{
    Console.WriteLine($"---{indice + 1}º número sorteado: {num} \n");
    if ((indice + 1 + 1) < 99)
    {
        Console.WriteLine($"pressione qualqer tecla pra exibir o proximo número!");
    }
    else
    {
        if (((indice + 1 + 1) == 99))
        {
            Console.WriteLine($"pressione qualqer tecla pra exibir o ultimo número!");
        }
    }
    Console.ReadKey();
}

int verificaLinha(int qt_jogadores, int qt_cartelas,int[,] count_linhas) 
{
    int contador = 0;

    for (int i = 0; i < qt_jogadores ; i++)
    {
        for (int j = 0; j < qt_cartelas; j++)
        {
            if (count_linhas[i,j] == 1) 
            {
                contador++;
            }
        }
    }

    return contador;
}
int verificaColuna(int qt_jogadores, int qt_cartelas, int[,] count_colunas)
{
    int contador = 0;

    for (int i = 0; i < qt_jogadores; i++)
    {
        for (int j = 0; j < qt_cartelas; j++)
        {
            if (count_colunas[i, j] == 1)
            {
                contador++;
            }
        }
    }

    return contador;
}

int verificaGanahdorCartela(int qt_jogadores, int qt_cartelas, int[,] count_cartela)
{
    int contador = 0;

    for (int i = 0; i < qt_jogadores; i++)
    {
        for (int j = 0; j < qt_cartelas; j++)
        {
            if (count_cartela[i, j] == 1)
            {
                contador++;
            }
        }
    }

    return contador;
}

void verificaCartela(int[,] matriz, int[,] matriz_aux,int sorteado ,ref int contador_linha, ref int contador_coluna, ref int contador_cartela)
{
    if (ganhador_coluna == false) 
    {
        rodada_coluna = sorteado;
    }
    if(ganhador_linha = false)
    {
        rodada_linha = sorteado;
    }
    if (ganhador_cartela == false)
    {
        rodada_cartela = sorteado;
    }
    for (int linhas = 0; linhas < 5; linhas++)
    {
        for(int colunas = 0;colunas < 5; colunas++)
        {
            if (matriz[linhas,colunas] == sorteado)
            {
                    matriz_aux[linhas, colunas] = 1;
                    contador_cartela++;
                if (contador_cartela == 25 && ganhador_cartela == false)
                {
                    ganhador_cartela = true;
                    contador_cartela = 1;
                }
                else
                {
                    if (ganhador_cartela == true && rodada_cartela == sorteado && contador_cartela == 25)
                    {
                        contador_cartela = 1;
                    }
                }
            }
            if (ganhador_coluna == false && matriz_aux[0, colunas] == 1 && matriz_aux[1,colunas] == 1 && matriz_aux[2,colunas] == 1 && matriz_aux[3,colunas] == 1 && matriz_aux[4,colunas] == 1)
            {
                ganhador_coluna = true;
                contador_coluna = 1;
                break;
            }
            else
            {
                if (ganhador_coluna == true && rodada_coluna == sorteado && matriz_aux[0, colunas] == 1 && matriz_aux[1, colunas] == 1 && matriz_aux[2, colunas] == 1 && matriz_aux[3, colunas] == 1 && matriz_aux[4, colunas] == 1)
                {
                    contador_coluna = 1;
                    break;
                }
            }
        }
        if (ganhador_linha == false && matriz_aux[linhas,0] == 1 && matriz_aux[linhas, 1] == 1 && matriz_aux[linhas, 2] == 1 && matriz_aux[linhas, 3] == 1 && matriz_aux[linhas, 4] == 1)
        {
            ganhador_linha = true;  
            if (contador_linha == 0)
            {
                contador_linha = 1;
            }

        }
        else
        {
            if (ganhador_linha == true && rodada_linha == sorteado && matriz_aux[linhas, 0] == 1 && matriz_aux[linhas, 1] == 1 && matriz_aux[linhas, 2] == 1 && matriz_aux[linhas, 3] == 1 && matriz_aux[linhas, 4] == 1)
            {
                if (contador_linha == 0)
                {
                    contador_linha = 1;
                }
            }
        }
        imprimirCartela(matriz,matriz_aux);
    }
}

int qtd_jogadores = quantidadeJogador();
int qtd_cartelas = quantidadeCartelas();
int[][][,] vetor_cartelas = new int[qtd_jogadores][][,];
int[][][,] vetor_cartelas_aux = new int[qtd_jogadores][][,];
int[,] contador_linha = new int[qtd_jogadores,qtd_cartelas];
int[,] contador_coluna = new int[qtd_jogadores, qtd_cartelas];
int[,] contador_cartela = new int[qtd_jogadores, qtd_cartelas];
//vetor_cartelas[1][4] = new int[5,5];


// cria o numero maximo de cartelas por jogador;
for (int i = 0; i < qtd_jogadores; i++)
{
    vetor_cartelas[i] = new int[qtd_cartelas][,];
    vetor_cartelas_aux[i] = new int[qtd_cartelas][,];
    for (int j = 0; j < qtd_cartelas; j++)

    {
        vetor_cartelas[i][j] = criarCartela();
        vetor_cartelas_aux[i][j] = new int[5, 5];
        int[,] cartela = vetor_cartelas[i][j];
        imprimirCartela(cartela, vetor_cartelas_aux[i][j]);
        Console.ReadLine();
    }
}

sorteiaNumeros();
int count_ganahdores_linhas = 0, count_ganhadores_coluna = 0, count_ganhadores_cartela = 0;
for (int rodadas = 0; rodadas < 99; rodadas++)
{
    int sorteado = sorteados[rodadas];
    imprimirNumerosSorteados(sorteado, rodadas);
    for (int i = 0; i < qtd_jogadores; i++) {//jogador

        for (int j = 0; j < qtd_cartelas; j++) // cartela
        {
            int[,] cartela = vetor_cartelas[i][j];        
            int[,] cartela_aux = vetor_cartelas_aux[i][j];        
            verificaCartela(cartela, cartela_aux,sorteado ,ref contador_linha[i,j], ref contador_coluna[i,j], ref contador_cartela[i,j]);
            Console.WriteLine(" jogador " + i + ", cartela " + j + ", contador linha: " + contador_linha[i,j]);

            // Console.ReadLine();

        }
    }
    if (ganhador_linha == true)
    {
       count_ganahdores_linhas  = verificaLinha(qtd_jogadores, qtd_cartelas, contador_linha);
    }
    if (ganhador_coluna == true)
    {
        count_ganhadores_coluna = verificaColuna(qtd_jogadores,qtd_cartelas, contador_coluna);
    }
    if (ganhador_cartela == true)
    {
        count_ganhadores_cartela = verificaGanahdorCartela(qtd_jogadores,qtd_cartelas, contador_cartela);
        break;
    }
 
}


//cartelaDoJogadorUm[0][0]

Console.WriteLine("Para");
Console.ReadLine();


