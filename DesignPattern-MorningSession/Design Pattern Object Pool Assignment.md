# **Design Pattern Assignment**

# **Object Pool Design Pattern**

**Introduction**

- It is a creational design pattern that can significantly improve the performance in the given cases: the cost of initialising a class instance is high, the number of instantiation in use at once in less and the rate of instantiation of a class is high.

- It is based on the principle that object once created object by the client is returned back to the pool, when the client will need it again, the object will be retrieved from the pool, but it will not be created again from the beginning since it has already been created. You can even set the number of objects that can be stored in the pool of objects. Object pool can be viewed as a cache for objects.

- This pool is either a growing one i.e. it creates new Objects when the pool is empty or it may restrict the creation of new Objects when the threshold is reached.

- It is particularly useful in case of a database or multithreading since the object pool class is singleton (thread-safe). Thus, it prevents multiple threads or transactions from accessing it simultaneously.

- The Object Pool is dynamic as it keeps cleaning the unused objects and creating new instances for those that have been &quot;_che_ck_ed out_&quot; by any process to avoid waiting time. The &quot;_checked out_&quot; objects need to be reset when returned to the pool so that client can work on the previous state of the object.

**Structure**

![](RackMultipart20200730-4-1bzq09d_html_d203f7301c478789.png)

- **Reusable**  - Instances of classes in this role collaborate with other objects for a limited amount of time, then they are no longer needed for that collaboration.
- **Client**  - Instances of classes in this role use Reusable objects.
- **ReusablePool**  - Instances of classes in this role manage Reusable objects for use by Client objects.

The above diagram clearly shows that Object pool class is the  **singleton** , because there is a **static getInstance()** method that creates an object in the class. The method **acquireReusable()**, is responsible for creating the object and saving it to the pool as a used object. The method **releaseReusable()** is responsible for releasing the object from the client, and inserting it into the pool of objects, if not recreated. The last method **setMaxPoolSize()** is responsible for setting the maximum number of available objects in the pool.

**Example**

The object pool pattern can be easily understood by seeing an office warehouse example with office equipment as the pool of objects (reusables) for the employees (clients).

![](RackMultipart20200730-4-1bzq09d_html_bd4149368af34011.png)

**JAVA Implementation**

**Step 1** Create an abstract ObjectPool class as below:

package com.codepumpkin.objectpool;

import java.util.Enumeration;

import java.util.Hashtable;

public abstract class ObjectPool\&lt;T\&gt; {

private long expirationTime;

private Hashtable\&lt;T, Long\&gt; locked, unlocked;

public ObjectPool() {

expirationTime = 30000; // 30 seconds

locked = new Hashtable\&lt;T, Long\&gt;();

unlocked = new Hashtable\&lt;T, Long\&gt;();

}

protected abstract T create();

public abstract boolean validate(T o);

public abstract void expire(T o);

public synchronized T getObject() {

long now = System.currentTimeMillis();

T t;

if (unlocked.size() \&gt; 0) {

Enumeration\&lt;T\&gt; e = unlocked.keys();

while (e.hasMoreElements()) {

t = e.nextElement();

if ((now - unlocked.get(t)) \&gt; expirationTime) {

// object has expired

unlocked.remove(t);

expire(t);

t = null;

} else {

if (validate(t)) {

unlocked.remove(t);

locked.put(t, now);

return (t);

} else {

// object failed validation

unlocked.remove(t);

expire(t);

t = null;

}

}

}

}

// no objects available, create a new one

t = create();

locked.put(t, now);

return (t);

}

public synchronized void releaseObject(T t) {

locked.remove(t);

unlocked.put(t, System.currentTimeMillis());

}

}

**Step 2** Extend the base class to the actual connection pool class for JDBC as below:

package com.codepumpkin.objectpool;

import java.sql.Connection;

import java.sql.DriverManager;

import java.sql.SQLException;

public class JDBCConnectionPool extends ObjectPool\&lt;Connection\&gt; {

private String url, usr, pwd;

public JDBCConnectionPool(String driver, String url, String usr, String pwd) {

super();

try {

Class.forName(driver).newInstance();

} catch (Exception e) {

e.printStackTrace();

}

this.url = url;

this.usr = usr;

this.pwd = pwd;

}

@Override

protected Connection create() {

try {

return (DriverManager.getConnection(url, usr, pwd));

} catch (SQLException e) {

e.printStackTrace();

return (null);

}

}

@Override

public void expire(Connection o) {

try {

((Connection) o).close();

} catch (SQLException e) {

e.printStackTrace();

}

}

@Override

public boolean validate(Connection o) {

try {

return (!((Connection) o).isClosed());

} catch (SQLException e) {

e.printStackTrace();

return (false);

}

}

}

**Step 3** Now we can use the extended class JDBCConnectionPool whenever required and return the object to the pool after usage as below:

// Create the ConnectionPool:

JDBCConnectionPool pool = new JDBCConnectionPool(

&quot;com.mysql.jdbc.Driver&quot;, &quot;jdbc:mysql://localhost:3306/mydb&quot;,

&quot;root&quot;, &quot;root&quot;);

// Get a connection:

Connection connection = pool.getObject();

// Use the connection

//...

// Return the connection:

pool.releaseObject(connection);
