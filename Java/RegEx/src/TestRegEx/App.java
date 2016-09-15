package TestRegEx;

import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class App {

	public static void main(String[] args) {

		Pattern pattern = Pattern.compile("^([+-]?)(\\d*)(\\.?)(\\d*)");

		Matcher matcher = pattern.matcher("-0.1");

		System.out.println("toMatchResult:" + matcher.toMatchResult().toString());

		
		boolean found = false;
		int i = 0;
		while (matcher.find()) {
			System.out.println(i++);
			System.out.format(
				"groupCount=%d\n" +
				"group='%s'\n" +
				"start=%d\n" +
				"end=%d\n" +
				"\n",
				matcher.groupCount()
				, matcher.group()
				, matcher.start()
				, matcher.end());
			
			found = true;
			
			for(int y=1 ; y<=matcher.groupCount() ; y++)
				System.out.format("group(%d):%s\n",y,matcher.group(y));
		}
		if (!found) {
			System.out.format("No match found.%n");
		}
	}
}
