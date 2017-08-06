using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    Dictionary<string, Clinic> clinics;
    Dictionary<string, Pet> pets;

    public Engine()
    {
        this.clinics = new Dictionary<string, Clinic>();
        this.pets = new Dictionary<string, Pet>();
    }

    public void Run()
    {
        this.Dispatch();
    }

    private void Dispatch()
    {
        int countCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countCommands; i++)
        {
            string[] inParams = Console.ReadLine().Split();
            string command = inParams[0];
            inParams = inParams.Skip(1).ToArray();

            switch (command)
            {
                case "Create":
                    if (inParams[0] == "Pet")
                    {
                        try
                        {
                            Pet newPet = new Pet(inParams[1], int.Parse(inParams[2]), inParams[3]);
                            this.pets.Add(inParams[1], newPet);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else if (inParams[0] == "Clinic")
                    {
                        try
                        {
                            Clinic newClinic = new Clinic(inParams[1], int.Parse(inParams[2]));
                            this.clinics.Add(inParams[1], newClinic);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                    break;

                case "Add":
                    Pet pet = this.pets.FirstOrDefault(x => x.Key == inParams[0]).Value;
                    Clinic clinic = this.clinics.FirstOrDefault(x => x.Key == inParams[1]).Value;
                    bool result = (pet != null) && (clinic != null);

                    if (result)
                    {
                        if (result = clinic.AddPet(pet))
                        {
                            this.pets.Remove(inParams[0]);
                        }
                    }
                    else
                    {
                        result = false;
                    }

                    Console.WriteLine(result);
                    break;

                case "Release":
                    Console.WriteLine(this.clinics[inParams[0]].Release());
                    break;

                case "HasEmptyRooms":
                    Console.WriteLine(this.clinics[inParams[0]].HasEmptyRooms());
                    break;

                case "Print":
                    if (inParams.Length == 1)
                    {
                        Console.WriteLine(this.clinics[inParams[0]].ToString());
                    }
                    else if (inParams.Length == 2)
                    {
                        Pet petForPrint = this.clinics[inParams[0]].Rooms[int.Parse(inParams[1]) - 1];
                        Console.WriteLine(petForPrint?.ToString() ?? "Room empty");
                    }
                    break;
            }
        }
    }
}