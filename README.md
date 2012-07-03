Exception Hash
=============

Exception Hash is a simple extension that allows you to create a hash for an exception.

The hash is based on the exceptions message, stack trace and inner exceptions.

This kind of hash is usefull if you want an easy way to identify a specific reocuring exception in your error tracking database.

For example all NullReferenceExceptions thrown from the method `ParseInt` will have the same hash making them easy to track down.