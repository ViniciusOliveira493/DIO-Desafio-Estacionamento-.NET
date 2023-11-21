using desafio_estacionamento.model;
using System.Reflection;

Decimal initialPrice = 0;
Decimal pricePerHour = 0;
Estacionamento e;

main();
void main()
{
    Console.WriteLine("Iniciando . . .");
    obtainStartValues();

    e = new Estacionamento(initialPrice,pricePerHour);

    while(true){
        int option = menu();
        switch (option)
        {
            case 1:
                register();
                break;
            case 2:
                remove();
                break;
            case 3:
                list();
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}

void register(){
    Console.WriteLine("Digite a placa do veículo para cadastrar");
    string licensePlate = Console.ReadLine().ToString();

    if(licensePlate!=null && licensePlate!=""){
        e.addCar(licensePlate);
        Console.WriteLine("Veículo cadastrado com sucesso \n");
    }
}

void remove(){
    Console.WriteLine("Digite a placa do veículo para remover \n");
    string licensePlate = Console.ReadLine().ToString();

    int hours = -1;
    while (hours < 0)
    {
        Console.WriteLine($"Digite a quantidade de horas que o veículo {licensePlate} ficou no estacionamento");
        hours = obterNumero();
    }
     
    string result = e.removeCar(licensePlate, hours);
    
    Console.WriteLine(result + "\n");
   
}

void list(){
    Console.WriteLine(e.listCars());
}

int menu()
{
    int option = 0;

    Console.WriteLine("Menu aperte um numero para prosseguir:");
    Console.WriteLine("1 - Cadastrar Veículo");
    Console.WriteLine("2 - Remover Veículo");
    Console.WriteLine("3 - Listar Veículos");
    Console.WriteLine("0 - Sair \n");

    option = obterNumero();

    Console.WriteLine();
    return option;
}

int obterNumero(){
    int integer = -1;
    try
    {            
        integer = Int32.Parse(Console.ReadLine());
    }
    catch (System.Exception)
    {
        Console.WriteLine("Você não digitou um número");
    }
    return integer;
}

bool obtainStartValues()
{
    Boolean inputOK = false;
    while (!inputOK)
    {
        try
        {
            Console.WriteLine("Digite o valor inicial");
            initialPrice = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor por hora");
            pricePerHour = Decimal.Parse(Console.ReadLine());    

            inputOK = true;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Um valor digitado é inválido");
        }
    }

    return inputOK;
}