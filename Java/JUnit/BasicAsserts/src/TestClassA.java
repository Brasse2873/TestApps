import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.junit.Test;

public class TestClassA {

	@Test
	public void AssertEqualsLong() {
		long hash = this.hashCode();
		assertEquals(hash, this.hashCode());
	}
	
	@Test
	public void AssertEqualsDouble(){
		assertEquals(1.5, 3.0/2.0,0.1);
	}
	
	@Test
	public void AssertEqualsString(){
		assertEquals("TestClassA",this.getClass().getName());
	}
	
	@Test
	public void AssertTrue(){
		assertTrue(this.hashCode()>0);
	}
	
	@Test
	public void AssertNotEqualsString(){
		assertNotEquals("Blaj", this.getClass().getSimpleName());
	}
	
	@Test
	public void AssertEqualsIntArray(){
		Integer[] array1 = new Integer[]{1,2,3};
		Integer[] array2 = new Integer[]{1,2,3};
		
		assertArrayEquals(array1, array2);
	}

}
