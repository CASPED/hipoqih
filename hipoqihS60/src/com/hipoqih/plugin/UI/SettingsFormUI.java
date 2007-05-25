package com.hipoqih.plugin.UI;

import javax.microedition.lcdui.*;
import javax.microedition.rms.RecordStoreException;

import com.hipoqih.plugin.*;

public class SettingsFormUI extends Form implements CommandListener 
{
	private StringItem labelUser = new StringItem("", "User :", StringItem.PLAIN);
	private TextField textUser = new TextField("", State.user, 16, TextField.NON_PREDICTIVE);
	private StringItem labelPass = new StringItem("", "Password:", StringItem.PLAIN);
	private TextField textPass = new TextField("", State.user, 16, TextField.NON_PREDICTIVE | TextField.PASSWORD);
	private Command cmdSave = new Command("Save", Command.SCREEN, 1);
	private Command cmdCancel = new Command("Cancel", Command.SCREEN, 1);
	private MainFormUI mainForm = null;

	public SettingsFormUI(MainFormUI mf)
	{
		super("HipoqihPlugin");
		setCommandListener(this);
		mainForm = mf;
		labelUser.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		this.append(labelUser);
		textUser.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		this.append(textUser);
		labelPass.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_2);
		this.append(labelPass);
		textPass.setLayout(Item.LAYOUT_LEFT | Item.LAYOUT_TOP | Item.LAYOUT_NEWLINE_AFTER | Item.LAYOUT_2);
		this.append(textPass);
		this.addCommand(cmdSave);
		this.addCommand(cmdCancel);
	}

	public void commandAction(Command command, Displayable displayable)
    {
		if (command == cmdSave)
		{
			State.user = textUser.getString();
			State.password = textPass.getString();
			try
			{
				Tools.updateRecord(RecordTypes.USER, State.user);
				Tools.updateRecord(RecordTypes.PASSWORD, State.password);
			}
			catch(RecordStoreException rse)
			{
				Alert alertScreen = new Alert("Error");
				alertScreen.setString("There was an error storing the data");
				alertScreen.setTimeout(Alert.FOREVER);
			}
			HipoqihMIDlet.getDisplay().setCurrent(mainForm);
		}
		if (command == cmdCancel)
		{
			HipoqihMIDlet.getDisplay().setCurrent(mainForm);
		}
    }
}
