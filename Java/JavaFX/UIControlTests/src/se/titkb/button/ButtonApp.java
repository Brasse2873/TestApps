package se.titkb.button;

import javafx.application.Application;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class ButtonApp extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		
		//Scene scene = new Scene(getUITest1());
		Scene scene = new Scene(getUITest2());
		primaryStage.setScene(scene);
		primaryStage.show();
	}
	
	private Parent getUITest1() throws Exception {
		Button btn =  new Button("First");
		return btn;
	}
	
	private Parent getUITest2() throws Exception {
		Pane pane = new Pane();
		pane.setPrefHeight(200);
		pane.setPrefWidth(200);
		
		Button btn = new Button("First");
		//btn.setPrefHeight(Double.MAX_VALUE);
		btn.setPrefWidth(Double.MAX_VALUE);
		pane.getChildren().add(btn);
		return pane;
	}
	
	

}
