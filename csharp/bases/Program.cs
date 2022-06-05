// See https://aka.ms/new-console-template for more information
using bases;

Console.WriteLine("Hello, World!");

double altura = 1.88;

System.Console.WriteLine($"La variable {nameof(altura)} tiene el valor de {altura}");

uint numeroNatural = 23;
int numeroEntero = -23;
float numeroReal = 2.3f;
double numeroRealDoble = 2.33333;
decimal numeroDecimal = 0.1M;
bool feliz = true;
var peso = 1.88;

int? valor = null;

System.Console.WriteLine($"Tipo de datot {nameof(peso)} es {peso.GetType()}");

string[] nombres = new string[4]; 
nombres[0] = "Carlos 1";
nombres[1] = "Carlos 2";
nombres[2] = "Carlos 3";
nombres[3] = "Carlos 4";
string[] apeliidos = new string[] {"Piedra","Gomez"}; 

for (int i = 0; i < nombres.Length; i++)
{
    System.Console.WriteLine(nombres[i]);
}

var persona = new Persona();
persona.Id = 1;
persona.Nombres="Carlos";
persona.Apellidos="Piedra";
System.Console.WriteLine($"Persona {persona.Nombres} {persona.Apellidos}");

var personas = new List<Persona>();



