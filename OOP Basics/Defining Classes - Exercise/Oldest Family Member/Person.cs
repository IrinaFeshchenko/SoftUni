﻿namespace Oldest_Family_Member
{
    public class Person
    {
        public string name;

        public int age;

        public Person()
            :this("No name",1)
        {
        }

        public Person(int age)
            :this("No name",age)
        {
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{this.name} {this.age}";
        }
    } 
}
