using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public class Type
    {
        private static List<Type> _instances = new List<Type> {};
        private string _name;
        private int _id;
        private List<Animal> _animals;

        public Type(string typeName)
        {
            _name = typeName;
            _instances.Add(this);
            _id = _instances.Count;
            _animals = new List<Animal>{};
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<Type> GetAll()
        {
            return _instances;
        }

        public static Type Find(int searchId)
        {
            return _instances[searchId - 1];
        }

        public List<Type> GetAnimals()
        {
            return _animals;
        }

    }
}
