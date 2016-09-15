package se.titkb.hbox;

import javafx.application.Application;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

public class KeypadApp extends Application{

	public static void main(String[] args) {
		launch();

	}

	@Override
	public void start(Stage stage) throws Exception {
		HBox inode;
		VBox onode = new VBox();
		
		inode = new HBox();
		inode.getChildren().add(new Button("7"));
		inode.getChildren().add(new Button("8"));
		inode.getChildren().add(new Button("9"));		
		onode.getChildren().add(inode);

		inode = new HBox();
		inode.getChildren().add(new Button("4"));
		inode.getChildren().add(new Button("5"));
		inode.getChildren().add(new Button("6"));		
		onode.getChildren().add(inode);

		inode = new HBox();
		inode.getChildren().add(new Button("1"));
		inode.getChildren().add(new Button("2"));
		inode.getChildren().add(new Button("3"));		
		onode.getChildren().add(inode);
		
		inode = new HBox();
		inode.getChildren().add(new Button("0"));
		inode.getChildren().add(new Button("00"));
		onode.getChildren().add(inode);
		
		
		Scene scene = new Scene(onode,250,250,Color.BLACK);
		stage.setScene(scene);
		stage.show();
	}

}
