#![cfg_attr(
    all(not(debug_assertions), target_os = "windows"),
    windows_subsystem = "windows"
)]

use tauri::Manager;

pub fn run() {
    tauri::Builder::default()
        .setup(|app| {
            let editor = app.get_webview_window("crosshair").unwrap();

            editor.set_ignore_cursor_events(true)?;
            editor.set_always_on_top(true)?;
            editor.center()?;
            


            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
