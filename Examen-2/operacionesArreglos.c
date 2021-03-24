#include <stdio.h>
#include <string.h>
#include <mpi.h>
#include <stdlib.h>



void process (int my_rank, int comm_size,int size, int* arreglo, int* totalSuma, int* totalMultiplicacion);
void llenar_vector(int* arreglo, int size);


int main(void){

    int comm_size;
    int my_rank;

    int size =0;
    int* totalSuma;
    int* totalMultiplicacion;
    int* arreglo;


    MPI_Init(NULL,NULL);
    MPI_Comm_size(MPI_COMM_WORLD, &comm_size);
    MPI_Comm_rank(MPI_COMM_WORLD, &my_rank);

    
    process(my_rank, comm_size,size, arreglo,totalSuma,totalMultiplicacion);


    MPI_Finalize();
    return 0;
}

void process (int my_rank, int comm_size, int size, int* arreglo, int* totalSuma, int* totalMultiplicacion)
{

    if(my_rank ==0){

        printf("Ingresar tamanio del arreglo:");
        scanf("%d",size); 
        if( size > 50)
        {
            printf("tamanio no valido");
            return; 
        }

        arreglo = (int *) calloc(size,sizeof(int));
        llenar_vector(arreglo, size);

        for(int i=1; i < comm_size; i ++){
            MPI_Recv(totalMultiplicacion, 1, MPI_DOUBLE, i,0,MPI_COMM_WORLD,MPI_STATUS_IGNORE);
            MPI_Recv(totalSuma, 1, MPI_DOUBLE, i,0,MPI_COMM_WORLD,MPI_STATUS_IGNORE);
        }

        printf("resultado de la suma: %ls \n",totalSuma);
        printf("resultado de la multiplicacion: %ls \n",totalMultiplicacion);

    }else{
        for(int i = 0; i <size ; i++){
            if(arreglo[i] % 2 ==0){
               *totalSuma += arreglo[i];
               MPI_Send(totalSuma,1,MPI_DOUBLE,0,0,MPI_COMM_WORLD); 
            }else{
                *totalMultiplicacion = *totalMultiplicacion * arreglo[i]
;                MPI_Send(totalMultiplicacion,1,MPI_DOUBLE,0,0,MPI_COMM_WORLD);
            }
        }
        
    }
}

void llenar_vector(int* arreglo, int size){
    srand(time(NULL));
     for(int i =0; i< size ; i++)
        {
            arreglo[i] = (rand()%150)+1;
        }  
}