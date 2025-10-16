using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._job = "Technical Writer";
        job1._comp = "Adobe";
        job1._startYear = 2021;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._job = "Missionary Mentor";
        job2._comp = "LDS Church";
        job2._startYear = 2022;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Bubbas";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
