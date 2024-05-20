namespace VideoRental;

public class RegularMovie(string name) : Movie(name, 2);

public class ChildrenMovie(string name) : Movie(name, 1);

public class NewReleaseMovie(string name) : Movie(name, 3);