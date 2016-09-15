package se.titkb.tilepane;

import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.TilePane;
import javafx.stage.Stage;

public class KeypadApp extends Application{

	public static void main(String[] args) {
		launch(args);
	}

	@Override
	public void start(Stage stage) throws Exception {
		TilePane pane = new TilePane();
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
		
		for( Node node : pane.getChildren() )
		{
			((Button)node).setMaxHeight(Double.MAX_VALUE);
			((Button)node).setMaxWidth(Double.MAX_VALUE);
		}
		((Button)pane.getChildren().get(0)).setMinHeight(50);
		Scene scene = new Scene(pane);
		
		stage.setScene(scene);
		stage.show();
		
	}

}
