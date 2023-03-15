using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using ZooManagement.Data;
using System;
using System.Globalization;

namespace ZooManagement.Data;

public static class SampleAnimals
{
    public const int NumberOfAnimals = 100;
    private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "1", "Leo", "M", "13091974" , "01012023"},
            new List<string> { "1", "Maureen", "F", "01012020" , "01022023"},
            new List<string> { "1", "Dennis", "M", "13092022" , "02012023"},
            new List<string> { "2", "Tigger", "M", "01011999" , "02012023"},
            new List<string> { "2", "Tilly", "F", "01011999" , "02012023"},
            new List<string> { "3", "Eddy", "M", "01011999" , "02012023"},
            new List<string> { "4", "Polly", "F", "01012010" , "01012010"},
            new List<string> { "4", "Penny", "F", "01012010" , "01012010"},
            new List<string> { "4", "Pansy", "F", "01012010" , "01012010"},
            new List<string> { "4", "Poppy", "F", "01012010" , "01012010"},
            new List<string> { "5", "Terror", "M", "01012010" , "01012011"},
            new List<string> { "5", "Fear", "M", "01012010" , "01012011"},
            new List<string> { "6", "Jaws", "M", "01011970" , "01012011"},
            new List<string> { "1", "Bob", "M", "13091974" , "01012023"},
            new List<string> { "1", "Doreen", "F", "01012020" , "01022023"},
            new List<string> { "1", "Roger", "M", "13092022" , "02012023"},
            new List<string> { "2", "Dopey", "M", "01011999" , "02012023"},
            new List<string> { "2", "Lyra", "F", "01011999" , "02012023"},
            new List<string> { "3", "Jim", "M", "01011999" , "02012023"},
            new List<string> { "4", "Emily", "F", "01012010" , "01012010"},
            new List<string> { "4", "Sarah", "F", "01012010" , "01012010"},
            new List<string> { "4", "Wanda", "F", "01012010" , "01012010"},
            new List<string> { "4", "Tina", "F", "01012010" , "01012010"},
            new List<string> { "5", "Eight", "M", "01012010" , "01012011"},
            new List<string> { "5", "Seven", "M", "01012010" , "01012011"},
            new List<string> { "6", "Aaargh", "M", "01011970" , "01012011"},
            new List<string> { "1", "Darren", "M", "13091974" , "01012023"},
            new List<string> { "1", "Margeret", "F", "01012020" , "01022023"},
            new List<string> { "1", "Dave", "M", "13092022" , "02012023"},
            new List<string> { "2", "Graham", "M", "01011999" , "02012023"},
            new List<string> { "2", "Marjorie", "F", "01011999" , "02012023"},
            new List<string> { "3", "Edwin", "M", "01011999" , "02012023"},
            new List<string> { "4", "Florence", "F", "01012010" , "01012010"},
            new List<string> { "4", "Rebecca", "F", "01012010" , "01012010"},
            new List<string> { "4", "Megan", "F", "01012010" , "01012010"},
            new List<string> { "4", "Hannah", "F", "01012010" , "01012010"},
            new List<string> { "5", "Hello", "M", "01012010" , "01012011"},
            new List<string> { "5", "Goodbye", "M", "01012010" , "01012011"},
            new List<string> { "6", "Daisy", "M", "01011970" , "01012011"},
            new List<string> { "1", "ALeo", "M", "13091974" , "01012023"},
            new List<string> { "1", "AMaureen", "F", "01012020" , "01022023"},
            new List<string> { "1", "ADennis", "M", "13092022" , "02012023"},
            new List<string> { "2", "ATigger", "M", "01011999" , "02012023"},
            new List<string> { "2", "ATilly", "F", "01011999" , "02012023"},
            new List<string> { "3", "AEddy", "M", "01011999" , "02012023"},
            new List<string> { "4", "APolly", "F", "01012010" , "01012010"},
            new List<string> { "4", "APenny", "F", "01012010" , "01012010"},
            new List<string> { "4", "APansy", "F", "01012010" , "01012010"},
            new List<string> { "4", "APoppy", "F", "01012010" , "01012010"},
            new List<string> { "5", "ATerror", "M", "01012010" , "01012011"},
            new List<string> { "5", "AFear", "M", "01012010" , "01012011"},
            new List<string> { "6", "AJaws", "M", "01011970" , "01012011"},
            new List<string> { "1", "ABob", "M", "13091974" , "01012023"},
            new List<string> { "1", "ADoreen", "F", "01012020" , "01022023"},
            new List<string> { "1", "ARoger", "M", "13092022" , "02012023"},
            new List<string> { "2", "ADopey", "M", "01011999" , "02012023"},
            new List<string> { "2", "ALyra", "F", "01011999" , "02012023"},
            new List<string> { "3", "AJim", "M", "01011999" , "02012023"},
            new List<string> { "4", "AEmily", "F", "01012010" , "01012010"},
            new List<string> { "4", "ASarah", "F", "01012010" , "01012010"},
            new List<string> { "4", "AWanda", "F", "01012010" , "01012010"},
            new List<string> { "4", "ATina", "F", "01012010" , "01012010"},
            new List<string> { "5", "AEight", "M", "01012010" , "01012011"},
            new List<string> { "5", "ASeven", "M", "01012010" , "01012011"},
            new List<string> { "6", "AAaargh", "M", "01011970" , "01012011"},
            new List<string> { "1", "ADarren", "M", "13091974" , "01012023"},
            new List<string> { "1", "AMargeret", "F", "01012020" , "01022023"},
            new List<string> { "1", "ADave", "M", "13092022" , "02012023"},
            new List<string> { "2", "AGraham", "M", "01011999" , "02012023"},
            new List<string> { "2", "AMarjorie", "F", "01011999" , "02012023"},
            new List<string> { "3", "AEdwin", "M", "01011999" , "02012023"},
            new List<string> { "4", "AFlorence", "F", "01012010" , "01012010"},
            new List<string> { "4", "ARebecca", "F", "01012010" , "01012010"},
            new List<string> { "4", "AMegan", "F", "01012010" , "01012010"},
            new List<string> { "4", "AHannah", "F", "01012010" , "01012010"},
            new List<string> { "5", "AHello", "M", "01012010" , "01012011"},
            new List<string> { "5", "AGoodbye", "M", "01012010" , "01012011"},
            new List<string> { "6", "ADaisy", "M", "01011970" , "01012011"},
            new List<string> { "1", "BALeo", "M", "13091974" , "01012023"},
            new List<string> { "1", "BABMaureen", "F", "01012020" , "01022023"},
            new List<string> { "1", "BADennis", "M", "13092022" , "02012023"},
            new List<string> { "2", "BATigger", "M", "01011999" , "02012023"},
            new List<string> { "2", "BATilly", "F", "01011999" , "02012023"},
            new List<string> { "3", "BAEddy", "M", "01011999" , "02012023"},
            new List<string> { "4", "BAPolly", "F", "01012010" , "01012010"},
            new List<string> { "4", "BAPenny", "F", "01012010" , "01012010"},
            new List<string> { "4", "BAPansy", "F", "01012010" , "01012010"},
            new List<string> { "4", "BAPoppy", "F", "01012010" , "01012010"},
            new List<string> { "5", "BATerror", "M", "01012010" , "01012011"},
            new List<string> { "5", "BBAFear", "M", "01012010" , "01012011"},
            new List<string> { "6", "BAJaws", "M", "01011970" , "01012011"},
            new List<string> { "1", "BABob", "M", "13091974" , "01012023"},
            new List<string> { "1", "BBADoreen", "F", "01012020" , "01022023"},
            new List<string> { "1", "BARoger", "M", "13092022" , "02012023"},
            new List<string> { "2", "BADopey", "M", "01011999" , "02012023"},
            new List<string> { "2", "BALyra", "F", "01011999" , "02012023"},
            new List<string> { "3", "BBAJim", "M", "01011999" , "02012023"},
            new List<string> { "4", "BAEmily", "F", "01012010" , "01012010"},
            new List<string> { "4", "BASarah", "F", "01012010" , "01012010"},
            new List<string> { "4", "BAWanda", "F", "01012010" , "01012010"},
            new List<string> { "4", "BBATina", "F", "01012010" , "01012010"},
            new List<string> { "5", "BAEight", "M", "01012010" , "01012011"},
            new List<string> { "5", "BASeven", "M", "01012010" , "01012011"},
            new List<string> { "6", "BAAaargh", "M", "01011970" , "01012011"},
            new List<string> { "1", "BADarren", "M", "13091974" , "01012023"},
            new List<string> { "1", "BAMargeret", "F", "01012020" , "01022023"},
            new List<string> { "1", "BADave", "M", "13092022" , "02012023"},
            new List<string> { "2", "BAGraham", "M", "01011999" , "02012023"},
            new List<string> { "2", "BAMarjorie", "F", "01011999" , "02012023"},
            new List<string> { "3", "BAEdwin", "M", "01011999" , "02012023"},
            new List<string> { "4", "BAFlorence", "F", "01012010" , "01012010"},
            new List<string> { "4", "BARebecca", "F", "01012010" , "01012010"},
            new List<string> { "4", "BBAMegan", "F", "01012010" , "01012010"},
            new List<string> { "4", "BAHannah", "F", "01012010" , "01012010"},
            new List<string> { "5", "BAHello", "M", "01012010" , "01012011"},
            new List<string> { "5", "BAGoodbye", "M", "01012010" , "01012011"},
            new List<string> { "6", "BADaisy", "M", "01011970" , "01012011"},
         };
    public static IEnumerable<Animal> AddAnimals()
    {
        return Enumerable.Range(0, NumberOfAnimals).Select(AddAnimal);
    }
    private static Animal AddAnimal(int index)
    {

        Random random = new Random();
        int randomNumber = random.Next(1, 6);

        return new Animal
        {

            SpeciesId = randomNumber,
            Name = Data[index][1],
            Sex = Data[index][2],
            DateOfBirth = DateOnly.FromDateTime(DateTime.ParseExact(Data[index][3], "ddMMyyyy", CultureInfo.InvariantCulture)),
            DateAcquired = DateOnly.FromDateTime(DateTime.ParseExact(Data[index][4], "ddMMyyyy", CultureInfo.InvariantCulture)),
        };
    }
}
