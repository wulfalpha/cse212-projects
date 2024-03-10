/// <summary>
/// This queue is circular.  When people are added via add_person, then they are added to the 
/// back of the queue (per FIFO rules).  When get_next_person is called, the next person
/// in the queue is displayed and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue {
    private Queue<Person> _people = new Queue<Person>();

    public int Length => _people.Count;

    public void AddPerson(string name, int turns) {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public void GetNextPerson() {
        if (!_people.Any())
            Console.WriteLine("No one in the queue.");
        else {
            Person person = _people.Dequeue();
            Console.WriteLine(person.Name);

            if (person.Turns < 0)
            {
                _people.Enqueue(person);
            }
            else
            {
                person.Turns -= 1;
                if (person.Turns > 0)
                {
                    _people.Enqueue(person);
                }
            }
        }
    }
    public override string ToString() {
        return _people.ToString();
    }
}