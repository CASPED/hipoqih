package hipoqih;

import java.util.Hashtable;

import javax.microedition.lcdui.Command;
import javax.microedition.lcdui.Display;
import javax.microedition.lcdui.Displayable;
import javax.microedition.lcdui.List;
import javax.microedition.midlet.MIDlet;

public class CommandHandler {

	/**
	 * An interface for a wrapper class which can invoke a method with no
	 * parameters.
	 */
	static public interface InvokeAble {
		void invoke();
	}

	private MIDlet midlet = null;

	private Hashtable displayables = new Hashtable();

	private Hashtable cmd2EndPoint = new Hashtable();

	private Hashtable preCmd2runnable = new Hashtable();

	private Hashtable postCmd2runnable = new Hashtable();

	private Hashtable listItemIndex2cmd = new Hashtable();

	private Hashtable exitCmds = new Hashtable();

	private Display display;

	private static CommandHandler commandHandler = null;

	public static CommandHandler getInstance() {
		if (commandHandler == null) {
			commandHandler = new CommandHandler();
		}

		return commandHandler;
	}

	public void initialize(MIDlet midlet) {
		this.midlet = midlet;
		this.display = Display.getDisplay(midlet);
	}

	public void start(Displayable startdisplay) {
		System.out.println(startdisplay.getTitle());
    	display.setCurrent(startdisplay);
	}

	public void registerDisplayable(Displayable displayable) {
		displayables.put(displayable.getClass().getName(), displayable);
	}

	public void registerCommand(Command cmd, String endPoint) {
		cmd2EndPoint.put(cmd, endPoint);
	}

	public void registerPreCommand(Command cmd, InvokeAble bindedPreCmd) {
		preCmd2runnable.put(cmd, bindedPreCmd);
	}

	public void registerPostCommand(Command cmd, InvokeAble bindedPostCmd) {
		postCmd2runnable.put(cmd, bindedPostCmd);
	}

	public void registerExitCommand(Command cmd, String bind) {
		exitCmds.put(cmd, bind);
	}

	public void registerListItemIndex2command(List list, int index, Command cmd) {
		if (list != null && cmd != null)
			listItemIndex2cmd.put(list.getClass().getName() + "#" + index, cmd);
	}

	public boolean handleCommand(Command cmd) {
		// if cmd is list selection, we change cmd to actual command
		if (cmd == List.SELECT_COMMAND) {
			if (display.getCurrent() instanceof List) {
				List list = (List) display.getCurrent();
				int index = list.getSelectedIndex();
				cmd = (Command) listItemIndex2cmd.get(list.getClass().getName()
						+ "#" + index);
			}
		}

		if (cmd != null && exitCmds.containsKey(cmd)) {
			invokePreCommand(cmd);
			midlet.notifyDestroyed();
			return false;
		}

		if (cmd == null)
			return false;

		String endPointName = (String) cmd2EndPoint.get(cmd);
		if (endPointName != null) {
			Displayable endPoint = (Displayable) displayables.get(endPointName);

			if (endPoint != null) {
				invokePreCommand(cmd);

				display.setCurrent(endPoint);

				invokePostCommand(cmd);

				return true;
			}
		}

		return false;
	}

	private void invokePreCommand(Command cmd) {
		InvokeAble i = (InvokeAble) preCmd2runnable.get(cmd);
		if (i != null)
			i.invoke();
	}

	private void invokePostCommand(Command cmd) {
		InvokeAble i = (InvokeAble) postCmd2runnable.get(cmd);
		if (i != null)
			i.invoke();
	}

}
