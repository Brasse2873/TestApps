package se.titkb.tilepane;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.TilePane;
import javafx.stage.Stage;

public class TilePaneApp extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage primaryStage) throws Exception {
		TilePane pane = new TilePane();
		
		pane.setPrefColumns(3);
		
		pane.getChildren().add(new Button("First"));
		pane.getChildren().add(new Button("Second"));
		pane.getChildren().add(new Button("Third"));
		pane.getChildren().add(new Button("Fourth"));
		
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
		
	}

}
