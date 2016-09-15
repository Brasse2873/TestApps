package se.titkb.borderpane;


import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

public class BorderPaneApp extends Application{

	public static void main(String[] args){
		launch(args);		
	}
	
	@Override
	public void start(Stage primaryStage) throws Exception {
		BorderPane pane = new BorderPane();

		pane.setTop(new Button("Top"));
		pane.setRight(new Button("Right"));
		pane.setBottom(new Button("Bottom"));
		pane.setLeft(new Button("Left"));
		pane.setCenter(new Button("Center"));
		
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
				
	}

}
