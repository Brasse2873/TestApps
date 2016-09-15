package se.titkb.flowpane;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;

public class KeypadApp extends Application{

	public static void main(String[] args) {
		launch(args);

	}

	@Override
	public void start(Stage stage) throws Exception {
		FlowPane pane = new FlowPane();
		pane.getChildren().add(new Button("7"));
		pane.getChildren().add(new Button("8"));
		pane.getChildren().add(new Button("9"));
		pane.getChildren().add(new Button("4"));
		pane.getChildren().add(new Button("5"));
		pane.getChildren().add(new Button("6"));
		pane.getChildren().add(new Button("1"));
		pane.getChildren().add(new Button("2"));
		pane.getChildren().add(new Button("3"));
		pane.getChildren().add(new Button("0"));
		pane.getChildren().add(new Button("00"));
		pane.getChildren().add(new Button("000"));
		
		Scene scene = new Scene(pane);
		
		stage.setScene(scene);
		stage.show();
	}

}
