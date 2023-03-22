#!/usr/bin/env python3

import os, re, time
from sys import argv

import gi
gi.require_version('Gtk', '3.0')
from gi.repository import Gtk

loc = '.'
if len(argv) > 1 and os.path.isdir(argv[1]):
	loc = argv[1][:-1] if argv[1][-1] == '/' else argv[1]
loc = os.path.abspath(loc)

class Dir:
	def __init__(self, path, stop):
		self.path = path
		self.stop = stop

class File:
	def __init__(self, path, name):
		self.path = path
		self.name = name
		self.date = os.path.getmtime(f'{path}/{name}')

class OrganizeWindow(Gtk.Window):
	def __init__(self):
		super().__init__(title = 'Organizer')
		self.connect('destroy', Gtk.main_quit)
		self.set_default_size(250, 125)

		table = Gtk.Table()
		self.add(table)
		row = 0

		lbl_path = Gtk.Label(label=loc)
		table.attach(lbl_path, 0, 2, row, row+1)
		row += 1

		btn_organize = Gtk.Button(label='Organize')
		btn_organize.connect('clicked', self.on_organize_clicked)
		btn_refresh = Gtk.Button(label='Refresh')
		btn_refresh.connect('clicked', self.on_refresh_clicked)

		table.attach(btn_organize, 0, 1, row, row+1)
		table.attach(btn_refresh , 1, 2, row, row+1)

	def on_organize_clicked(self, button):
		dirs: list[Dir] = []
		files: list[File] = []
		for root, d, f in os.walk(loc):
			files += [File(root, x) for x in f]
			if len(d):
				continue
			print(root)
			n = re.findall(r'(\d+)K', os.path.basename(root))
			if len(n):
				dirs.append(Dir(root, int(n[0]) * 1000))
		files.sort(key=lambda x: x.date)
		dirs.sort(key=lambda x: x.stop)
		total = len(files)
		for d in dirs:
			if d.stop > total:
				d.stop = total
		dirs.append(Dir(loc, total))

		i = 0
		for d in dirs:
			while i < d.stop:
				f = files[i]
				if f.path != d.path:
					os.rename(f'{f.path}/{f.name}', f'{d.path}/{f.name}')
				i += 1

	def on_refresh_clicked(self, button):
		files: list[File] = []
		for root, d, f in os.walk(loc):
			if len(d):
				continue
			files.append(File(root, f[0]))
		files.sort(key=lambda x: x.date)
		for f in files:
			real = f'{f.path}/{f.name}'
			fake = f'{f.path}/a{f.name}'
			os.rename(real, fake)
			os.rename(fake, real)
			time.sleep(1.1)
#end OrganizeWindow

OrganizeWindow().show_all()
Gtk.main()
