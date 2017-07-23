namespace Problem_4___Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Patient
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }

    class Department
    {
        public Department(string departmentName)
        {
            Patients = new List<Patient>();

        }
        public string DepartmentName { get; set; }
        public List<Patient> Patients { get; set; }

    }


    class Program
    {
        static int roomsInDepartment = 20;
        static int bedsInRoom = 3;
        static int bedsLimit = bedsInRoom * roomsInDepartment;

        static void Main()
        {
            Dictionary<string, Department> hospital = new Dictionary<string, Department>();

            while (true)
            {
                List<string> tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (tokens[0] == "Output") break;

                string departmentName = tokens[0];
                string doctorName = $"{tokens[1]} {tokens[2]}";
                string patientName = tokens[3];

                if (!hospital.ContainsKey(departmentName))
                {
                    hospital.Add(departmentName, new Department(departmentName));
                }

                Patient newPatient = new Patient() { PatientName = patientName, DoctorName = doctorName };

                if ((!hospital[departmentName].Patients.Any()) ||
                   (hospital[departmentName].Patients.Count < bedsLimit))
                {
                    hospital[departmentName].Patients.Add(newPatient);
                }
            }

            PrintOutput(hospital);
        }

        private static void PrintOutput(Dictionary<string, Department> hospital)
        {

            while (true)
            {
                string[] filter = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (filter[0] == "End") break;

                int room;

                if (filter.Count() == 1)
                {
                    PrintDepartments(hospital, filter[0]);
                }
                else
                {
                    if (int.TryParse(filter[1], out room))
                    {
                        string department = filter[0];
                        PrintDepartmentAndRoom(hospital, department, room);
                    }
                    else
                    {
                        string doctorName = $"{filter[0]} {filter[1]}";
                        PrintDoctor(hospital, doctorName);
                    }
                }
            }
        }

        private static void PrintDoctor(Dictionary<string, Department> hospital, string filter)
        {
            List<string> result = new List<string>();

            foreach (var department in hospital)
            {
                foreach (var patient in department.Value.Patients)
                {
                    if (patient.DoctorName == filter)
                    {
                        result.Add(patient.PatientName);
                    }
                }
            }

            foreach (var item in result.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintDepartments(Dictionary<string, Department> hospital, string filter)
        {
            foreach (var patient in hospital[filter].Patients)
            {
                Console.WriteLine(patient.PatientName);
            }
        }

        private static void PrintDepartmentAndRoom(Dictionary<string, Department> hospital, string department, int room)
        {
            List<string> result = new List<string>();

            foreach (var patient in hospital[department].Patients
                                                        .Skip(bedsInRoom * (room - 1))
                                                        .Take(bedsInRoom)
                                                        .OrderBy(x => x.PatientName))

            {
                Console.WriteLine(patient.PatientName);
            }
        }
    }
}