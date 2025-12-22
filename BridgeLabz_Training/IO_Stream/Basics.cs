/*
-----------------------------------------------------
** I/O STREAMS: **
-----------------------------------------------------
-> It is the sequence of bytes, that we can read from, or write to.

-> It hides from where the data is coming from.
 
-> Almost all streams derive from the abstract class.
-----------------------------------------------------
-> In .NET, almost ALL STREAMS DERIVE from the ABSTRACT CLASSES like this:
-----------------------------------------------------
public abstract class Stream : IDisposable
{

1) Read : reads bytes into a buffer.
    
-> public abstract int Read(byte[] buffer, int offset, int count);


2) Write: writes bytes from a buffer to the stream
    
-> public abstract void Write(byte[] buffer, int offset, int count);


3) Seek: move the internal position (if the stream supports seeking).
    
-> public abstract long Seek(long offset, SeekOrigin origin);


4) Flush(): forces any buffered data to be written out.
    
-> public abstract void Flush();


5) Dispose()/Close(): release resources (important for files, network, etc.).
    
-> public abstract void Close();
}
-----------------------------------------------------
1) Buffer 
-> Temporary storage area (usually in RAM) used to hold data before it is processed.

-> It is used reduce the slow I/O operations,
by grouping data into bigger blocks.


2) Offset
-> Starting position inside the buffer (the byte array).

It tells the stream: 
“From which index of the buffer should I start reading or writing data?”


3) Count
-> How many bytes you want to read or write.
-----------------------------------------------------
TYPES OF STREAMS:
-----------------------------------------------------
1. File Streams
2. Object Streams
3. ByteArray Streams
4. Buffered Streams
5. Reader and Writer
-----------------------------------------------------
1) FILE STREAM
-> It is used to read/write files from/to disk.
 Namespace: System.IO
 
2) OBJECT STREAM
-> It is used to serialize the objects to a stream and to deserialize it back.

-> Unlike Java, C# doesn’t have ObjectInputStream / ObjectOutputStream like Java, but the idea remains same.

3) BYTE-ARRAY STREAM (Memory Stream)
-> It is a stream whose source/target is a byte array in memory, not a file.






 */