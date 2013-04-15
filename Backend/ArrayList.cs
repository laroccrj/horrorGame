using UnityEngine;
using System.Collections.Generic;

public class ArrayList<T> : object   {

	private T[] contents;
	private int size = 0;
	private int max = 20;
	
	public IEnumerator<T> GetEnumerator ()
	{
		if (contents != null)
		{
			for (int i = 0; i < size; ++i)
			{
				yield return contents[i];
			}
		}
	}
	
	public ArrayList() {
		this.contents = new T[this.max];
	}
	
	public ArrayList(int max) {
		this.max = max;
		this.contents = new T[this.max];
	}
	
	private void Increase_Capacity() {
		this.max *= 2;
		T[] old = this.contents;
		this.contents = new T[this.max];
		for(int i = 0; i < this.size; i++)
			this.contents[i] = old[i];
	}
	
	public void Add(T item) {
		if(this.size == this.max) Increase_Capacity();
		
		this.contents[size] = item;
		size++;
	}
	
	public bool Contains(T item) {
		return Search(item) != -1;
	}
	
	
	public int Search(T item) {
		for(int i = 0; i < this.size; i++){
			if(this.contents[i].Equals(item)) return i;
		}
		
		return -1;
	}
	
	public void Remove(T item) {
		int index = Search(item);
		
		if(index == -1) return;
		
		if(index != this.size){
			for(int i = index; i < this.size - 1; i++)
				this.contents[i] = this.contents[i + 1];
		}
		
		this.size--;
			
	}
	
	public T Get(int index) {
		return this.contents[index];
	}
	
	public T[] Get_Contents(){
		return this.contents;	
	}
}
