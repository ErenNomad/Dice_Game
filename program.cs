using System;
using System.Collections.Generic;

namespace DiceGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameDice game = new GameDice();
            int choice = 0;  
            string? selected = null;

            while (true)
            {
                if (choice == 0){
                    Console.WriteLine("*****************************************************************");
                    Console.Write("1-Oyuna Başla    \t2-Oyun Geçmişi   \t3-Oyundan Çıkış  \nİşlem seçiniz --> ");
                    selected = Console.ReadLine();
                    choice = choice + 1;
                    if (selected != "1"){
                        choice = 0;
                    }
                }
                else if (choice == 1){
                    Console.WriteLine("*****************************************************************");
                    Console.Write("1-Yeniden Oyna   |\t2-Oyun Geçmişi   |\t3-Oyundan Çıkış  \nİşlem seçiniz --> ");
                    selected = Console.ReadLine();
                    Console.WriteLine("*****************************************************************");
                }
                if (selected == "1" && choice == 0){
                    game.Playerİnformation();
                    game.DiceRolls();
                }
                else if (selected == "1" && choice == 1){
                    game.Clean();
                    game.Playerİnformation();
                    game.DiceRolls();
                }
                else if (selected == "2"){
                    int shots = 1;
                    foreach (var i in game.data_saver)
                    {
                        Console.WriteLine($"{shots}. atış : {i}");
                        shots++;
                    }
                }
                else if (selected == "3"){
                    game.Clean();
                    break;
                }
            }
        }
        class GameDice
        {
            public int total_roll = 0;
            public int point = 0;
            public List<string> data_saver = new();
            public void Playerİnformation()
            {
                Console.Write("Adınızı giriniz -->  ");
                string name = Console.ReadLine();
                name = name.Replace(" ", "");

                Console.Write("Soyadınızı giriniz -->  ");
                string surname = Console.ReadLine();
                Console.Write("Doğum tarihinizi giriniz (**.**.****) -->  ");
                string date = Console.ReadLine();
                int month = Convert.ToInt32(date.Substring(3, 2));
                if (name.Length > surname.Length){
                    point += 50;
                }
                else if (name.Length == surname.Length){
                    point += 25;
                }
                else if (name.Length < surname.Length){
                    point -= 25;
                }
                point = month <= 6 ? point + 30 : point - 20;
            }
            public void DiceRolls()
            {
                Random rastgele_num = new Random();
                while (total_roll < 10){
                    int roll = rastgele_num.Next(1, 7);
                    if (roll == 1 || roll == 6){
                        total_roll++;
                        if (roll == 1){
                            data_saver.Add($"Gelen zar {roll} bu yüzden 75 puan kaybettiniz.");
                            point -= 75;
                        }
                        if (roll == 6){
                            data_saver.Add($"Gelen zar {roll} bu sayede 100 puan kazandınız.");
                            point += 100;
                        }
                    }
                    else{
                        data_saver.Add($"Gelen zar {roll} zar tekrar atılıyor...");
                    }
                }
                if (point < 500){
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine($"\t...Toplam puanınız {point}...\n\t...Oyunu kaybettiniz...");
                    Console.WriteLine("*****************************************************************");
                }
                else{
                    Console.WriteLine("*****************************************************************");
                    Console.WriteLine($"\t...Toplam puanınız {point}...\n\t...Oyunu kazandınız...");
                    Console.WriteLine("*****************************************************************");
                }
            }
            public void Clean()
            {
                total_roll = 0;
                point = 0;
                data_saver.Clear();
            }
        }
    }
}
