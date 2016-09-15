package se.titkb.helloworldfxml;
import java.net.URL;
import java.util.ResourceBundle;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.TextField;

public class HelloWorldController implements Initializable {

	@FXML
	private TextField myTextField;
	
	@Override
	public void initialize(URL arg0, ResourceBundle arg1) {
			myTextField.setText("HelloWorld");
	}
	
	@FXML
	public void myButtonAction(ActionEvent event){
		System.out.println("myButton Clicked");
		System.out.println("myTextField=" + myTextField.getText());
	}

}
