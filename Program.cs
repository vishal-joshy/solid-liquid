RDParser parser = new RDParser("1+2+3-2");
Expression exp = parser.DoParse();

Console.Write(exp.Evaluate());