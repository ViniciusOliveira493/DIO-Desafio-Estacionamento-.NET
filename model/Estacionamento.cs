using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_estacionamento.model
{
    public class Estacionamento
    {
        private Decimal initialPrice;
        private Decimal pricePerHour;
        private List<string> cars  = new List<string>();

        public Estacionamento(Decimal initialPrice,Decimal pricePerHour){
            this.initialPrice = initialPrice;
            this.pricePerHour = pricePerHour;
            this.cars  = new List<string>();
        }

        public string addCar(String licensePlate){
            this.cars.Add(licensePlate);
            return licensePlate;
        }

        public string removeCar(String licensePlate, int hours){
            string result = "";

            if(cars.Any(x => x.ToUpper() == licensePlate.ToUpper()))
            {
                Decimal price = (hours * pricePerHour) + initialPrice;
                cars.Remove(licensePlate);  
                result = $"O veículo foi removido e o valor a ser cobrado é {price.ToString("C")}";
            }
            else
            {
                result = "Esse veículo não foi encontrado no estacionamento, verique se a placa foi digitada corretamente";
            }
            return result;
        }

        public string listCars(){
            string carList = "";
            carList+="Veículos no Estacionamento \n";
            
            for(int i=0 ; i<cars.Count; i++)
            {
                carList += (i+1)+" - "+ cars[i] + "\n";
            }
            return carList;
        }
    }
}