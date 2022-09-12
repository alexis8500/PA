#include "stdint.h"
#include "stdio.h"

int calk(int numero)
{
    /* des-integracion */
    uint8_t descomp[4];
    printf("numero: %i\n", numero);
    descomp[0] = numero / 1000;
    numero -= descomp[0] * 1000;
    descomp[1] = numero / 100;
    numero -= descomp[1] * 100;
    descomp[2] = numero / 10;
    numero -= descomp[2] * 10;
    descomp[3] = numero;
    /* comprobacion */
    for (int i = 1; i < 3; i++)
        if (descomp[0] == descomp[1] && descomp[0] == descomp[2]
            && descomp[0] == descomp[3]) // si todas sus cifras son iguales
            return 0; // devuelve 0

    /* ordenacion de mayor a menor */
    char dmayor[4];
    uint8_t dmenor[4];
    int numeroc;
    for (int y = 0; y < 4; y++) {
        numeroc = 0;
        for (int i = 0; i < 4; i++) {
            if (descomp[i] > numeroc)
                numeroc = descomp[i];
            dmayor[y] = numeroc;
        }
        for (int i = 0; i < 4; i++)
            if (descomp[i] == dmayor[y])
                descomp[i] = 0;
    }
    /* ordenacion de menor a mayor */
    for (int i = 0; i < 4; i++)
        dmenor[i] = dmayor[3 - i];
    /* integracion */
    int a;
    a = dmayor[0] * 1000;
    a += dmayor[1] * 100;
    a += dmayor[2] * 10;
    a += dmayor[3];
    int b;
    b = dmenor[0] * 1000;
    b += dmenor[1] * 100;
    b += dmenor[2] * 10;
    b += dmenor[3];
    /* resta */
    int resta = a - b;
    printf("%i - %i  = %i\n", a, b, resta);
    return resta;
}

int main(int argc, char* argv[])
{
    int numero; // variable para la  consulta
    while (numero > 9999 || numero < 1000) // nos aseguramos que es de 4 cifras
    {
        printf("Introduce un numero de cuatro cifras:");
        scanf("%i", &numero);
    }
    for (int i = 0; i < 10; i++) {
        numero = calk(numero);
        if (numero == 0)
            break;
        if (numero == 6174) {
            printf("Conseguido!!!\n");
            break;
        }
    }
    if (numero != 6174)
        printf("Atencion!!! el numero introducido tiene las cuatro cifras iguales, utiliza un numero diferente.\n");

    return 0;
}