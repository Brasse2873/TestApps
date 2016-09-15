import static org.junit.Assert.*;

import org.junit.Test;
import org.junit.experimental.categories.Category;

public class TestClassA {

	@Test
	@Category(GoodTestsCategory.class)
	public void test1() {
		System.out.println("TestClassA:test1");
	}

	@Test
	public void test2() {
		System.out.println("TestClassA:test2");
	}
}
