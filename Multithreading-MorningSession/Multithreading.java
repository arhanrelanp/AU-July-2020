


import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;




// blocking queue
class BlockingQueue
{
    private static List queue =  new LinkedList();
    private static final int limit = 10;
    private static int value = 0;
    // locking object
    public static Object lock =  new Object();

    // inserting into queue
    static boolean put()
    {
        // insert only when number of element is not greater than max size
        if(queue.size() <= limit)
        {
            System.out.println("Inserting "+(value++) +" in queue at "+queue.size());
            queue.add(value);
            lock.notifyAll();
            return true;
        }
        return false;
    }

    // deleting from queue
    static boolean take()
    {
        if(queue.size() > 0)
        {
            System.out.println("Deleting "+(value--)+" from queue at "+queue.size());
            queue.remove(0);
            lock.notify();
            return true;
        }
        return false;
    }
}

// producer thread
class producer extends Thread
{
    public void run()
    {
        while(true)
        {
            synchronized (BlockingQueue.lock) {
                System.out.print(this.getName()+" : ");

                if(!BlockingQueue.put())
                {
                    System.out.println("Queue is full. Task is already taken by any of the consumer.");
                    try {
                        BlockingQueue.lock.wait();
                    } catch(InterruptedException e) {
                        System.out.println(e.getMessage());
                    }
                }
            }


        }
    }
}


//consumer thread
class Consumer extends Thread
{
    public void run()
    {
        while(true)
        {
            synchronized (BlockingQueue.lock) {
                System.out.print(this.getName()+" - ");
                if(!BlockingQueue.take())
                {
                    System.out.println("Queue is empty. There is no task present in the queue.");
                    try {
                        BlockingQueue.lock.wait();
                    } catch(InterruptedException e) {
                        System.out.println(e.getMessage());
                    }
                }
            }


        }
    }
}

public class Multithreading {
    public static void main(String []args)
    {
        producer p = new producer();
        p.start();
        ExecutorService poolP = Executors.newSingleThreadExecutor();
        poolP.execute(p);

        final int numberOfConsumerThread = 10;

        ExecutorService poolC = Executors.newCachedThreadPool();

        for (int i = 0; i < numberOfConsumerThread; i++) {
            // consumer thread
            Consumer c = new Consumer();
            c.start();
            poolC.execute(c);
        }
    }
}