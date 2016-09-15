import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class BasicJUnit {

	@Before
	public void setUp(){
		System.out.println("setUp");
	}
	
	@Test
	public void test() {
		System.out.println("test");
	}
	
	@After
	public void tearDown(){
		System.out.println("tearDown");
	}

}
