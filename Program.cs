// See https://aka.ms/new-console-template for more information
using dio_dotnet_poo.src;
using dio_dotnet_poo.src.Entities;

Random random = new Random();

BattleRoyale battleRoyale = new BattleRoyale();
battleRoyale.addToBattle(new Knight("Arus",random.Next(1,30)));
battleRoyale.addToBattle(new Ninja("Wedge",random.Next(1,30)));
battleRoyale.addToBattle(new WhiteWizard("Jenica",random.Next(1,30)));
battleRoyale.addToBattle(new BlackWizard("Topapa",random.Next(1,30)));
battleRoyale.start();