using System.Threading;
// Класс Thread
/* ExecutionContext - позволяет получить контекст, в котором выполняется поток
 * IsAlive - указывает, работате ли поток в текущей момент
 * IsBackground - указывает, является ли поток фоновым
 * Name - имя потока
 * ManagedThreading - возвращает числовой идентификатор текущего потока
 * Priority - хранит приоритет потока - значения перечисления ThreadPriopity (Lowest/BelowNormal/Normal/AboveNormal/Highest)
 * CurrentThread - позволяет получить текущий поток
 */
//ThreadState возращает состояние потока - одно из значений перечисления
/* Aborted - поток остановлен, но пока еще окончательно не завершен
 * AbrotRequested - для потока вызван метод Abort, но остановка потока еще не произошла
 * Background - поток выполняется в фоновом режиме
 * Running - поток запущен и работает(не приостановлен)
 * Stopped - поток завершен
 * StopRequested - поток получил запрос на остановку
 * SuspendRequested - поток приостановлен
 * Unstarted - поток не был запущен
 * WaitSleepJoin - поток заблокирован в результате действия методов Sleep или Join
 */
//Thread currentThread = Thread.CurrentThread;
//Console.WriteLine($"Имя потока: {currentThread.Name}");
//currentThread.Name = "Метод Main";
//Console.WriteLine($"Имя потока: {currentThread.Name}");

//Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
//Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
//Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
//Console.WriteLine($"Статус потока: {currentThread.ThreadState}");
//Console.WriteLine("***********************************");
//Thread
/* GetDomain
 * GetDomainID
 * Sleep
 * Interrupt
 * Join
 * Start
 */
//Конструкторы класса Thread:
/* Thread(ThreadStart) - принимает в качестве параметра делегат
 * Thread(ThreadStart, Int32) - в дополнение к делегату ThreadStart принимает числовое значение, 
 * которое устанавливает размер стека для данного потока
 * Thread(ParameterizedThreadStart) - делегат, который представляет выполняемое действие в потоке
 * Thread(ParameterizedThreadStart, Int32) - принимает делегат и числовое значение, 
 * которое устанавливает размер стэка для данного потока
 */
/*Thread myThread = new Thread(Print);
myThread.Start();

for(int i = 0; i < 10; i++)
{
    Console.WriteLine($"Главный поток: {i}");
    Thread.Sleep(800);
}
void Print()
{
    for(int i = 0;i < 10;i++)
    {
        Console.WriteLine($"Второй поток: {i}");
        Thread.Sleep(800);
    }
}
Console.WriteLine("*********************");
Thread myThread2= new Thread(Print1);
Thread myThread1 = new Thread(new ParameterizedThreadStart(Print1));
Thread myThread3= new Thread(message=>Console.WriteLine(message));

myThread1.Start("Hello");
myThread2.Start("Привет");
myThread3.Start("Salut");

void Print1(object? message)=> Console.WriteLine(message);
Console.WriteLine("**********************");
int number = 5;
Thread myThread4= new Thread(Print2);
myThread4.Start(number);

Human ted = new Human("Ted", 48);
Thread myThread5 = new Thread(ted.Print);
myThread5.Start();
void Print2(object? obj)
{
    if (obj is int n)
        Console.WriteLine($"n * n = {n * n}");
}


record Human(string Name, int Age)
{
    public void Print()
    {
        Console.WriteLine($"Name - {Name}");
        Console.WriteLine($"Age - {Age}");
    }
}*/
int x = 0;
object locker = new();
AutoResetEvent waitHandler = new AutoResetEvent(true);
for(int i=1;i<6;i++)
{
    Thread myThread = new(Print);
    myThread.Name=$"Поток {i}";
    myThread.Start();
}

//void Print()
//{
//    lock (locker)
//    {
//        x = 1;
//        for (int i = 1; i < 101; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}
//Monitor System.Threading.Monitor
/* void Enter(object obj) - получает в эксклюзивное владение объект, передаваемый в качестве параметра.
 * void Enter(object obj, bool acquiredLock) - дополнительно принимает второй объект параметра -  логическое значение, 
 * которое указывает, получено ли владение над объектом из первого параметра
 * void Exit(object obj) - освобождение ранее захваченный объект
 * bool IsEntered(object obj) - возвращает true, если монитор захватил объект obj
 * void Pulse(object obj) - уведомляет поток из очереди ожидания, что текущий поток совободил объект obj
 * void PulseAll(object obj) - уведомляет поток из очереди ожидания, что текущий поток совободил объект obj. 
 * После чего один из потоков из очереди ожидания захватывает объект obj
 * bool TryEnter(object obj) - пытается захватить объект obj. Если владение над объектом успешно получено, 
 * то возвращает значение true
 * bool Wait(object obj) - освобождает блокировку объекта и переводит поток в очередь ожидания объекта. 
 * Следующий поток в очереди готовности объекта блокирует данный объект. А все потоки, которые вызвали метод Wait, 
 * остаются в очереди ожидания, пока не получат сигнал от метода Monitor.PulseAll, посланного владельцем блокировки
 */
//void Print()
//{
//    bool acquiredLock=false;
//    try
//    {
//        Monitor.Enter(locker,ref acquiredLock);
//        x = 1;
//        for (int i = 1; i < 101; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        if(acquiredLock)Monitor.Exit(locker);
//    }
//}
/*****************************************************************/
//Класс AutoResetEvent
/* Reset() - задает несигнальное состояние объекта, блокируя потоки
 * Set() - задает сигнальное состояние объекта, позволяя одному или нескольким ожидающим потокам продолжить работу
 * WaitOne() - задает несигнальное состояние и блокирует текущий поток, пока текущий объект AutoResetEvent не получит сигнал
 */
void Print()
{
    waitHandler.WaitOne();
    x = 1;
    for (int i = 1; i < 101; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
    }
    waitHandler.Set();
}