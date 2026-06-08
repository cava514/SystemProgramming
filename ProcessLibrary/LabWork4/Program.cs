using ProcessLibrary;

Tasklist tasklist = new Tasklist();

tasklist.GetThreadAliveAll();
tasklist.GetThreadByMaxId();
tasklist.GetThreadByName("notepad.exe");
tasklist.StartingANewProcess("notepad.exe");
